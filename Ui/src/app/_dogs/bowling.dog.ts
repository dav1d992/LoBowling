import { Injectable } from '@angular/core';
import { Frame } from '../_models/frame';
import { Game } from '../_models/game';
import { User } from '../_models/user';
import { FrameService } from '../_services/frame.service';
import { UserService } from '../_services/user.service';

@Injectable({
  providedIn: 'root',
})
export class BowlingDog {
  public frames: Frame[] = [];
  public games: Game[] = [];
  public users: User[] = [];

  constructor(
    private frameService: FrameService,
    private userService: UserService
  ) {
    this.frameService.getFrames().subscribe({
      next: (res: Frame[]) => {
        for (let frameIndex = 0; frameIndex < res.length; frameIndex++) {
          this.frames[frameIndex] = res[frameIndex];
          this.frames[frameIndex].isStrike = this.isStrike(res[frameIndex]);
          this.frames[frameIndex].isSpare = this.isSpare(res[frameIndex]);
        }
        this.calculateBonusPoints();
      },
      complete: () => {
        this.addAllFramesScores();
        this.populateGames();
      },
      error: (err) => {
        console.log('Failed to load frames', err);
      },
    });

    this.userService.getUsers().subscribe({
      next: (res: User[]) => {
        this.users = res;
      },
      error: (err) => {
        console.log('Failed to load frames', err);
      },
    });
  }

  isStrike(frame: Frame): boolean {
    return frame.firstRoll === 10;
  }

  isSpare(frame: Frame): boolean {
    return frame.firstRoll + frame.secondRoll === 10 && frame.firstRoll !== 10;
  }

  calculateBonusPoints(): void {
    for (var i = 0; i < this.frames.length; i++) {
      // STRIKE
      if (this.frames[i].isStrike) {
        if (this.frames[i].frameNumber === 9) {
          this.frames[i].bonusPoints = this.getRawScore(this.frames[i + 1]);
        } else if (this.frames[i].frameNumber === 10) {
          this.frames[i].bonusPoints = 0;
        } else {
          this.frames[i].bonusPoints = this.frames[i + 1].isStrike
            ? this.frames[i + 1].firstRoll + this.frames[i + 2].firstRoll
            : this.frames[i + 1].firstRoll + this.frames[i + 1].secondRoll;
        }
      }
      // SPARE
      else if (this.frames[i].isSpare) {
        console.log(this.frames[i]);
        if (this.frames[i].frameNumber === 10) {
          this.frames[i].bonusPoints = this.frames[i].thirdRoll;
        } else {
          this.frames[i].bonusPoints = this.frames[i + 1].firstRoll;
        }
      } else {
        this.frames[i].bonusPoints = 0;
      }
    }
  }

  addAllFramesScores(): void {
    for (let frame of this.frames) {
      frame.score = this.getTotalFrameScore(frame);
    }
  }

  getTotalFrameScore(frame: Frame): number {
    return (
      frame.firstRoll + frame.secondRoll + frame.thirdRoll + frame.bonusPoints
    );
  }

  getScore(frame: Frame): number {
    return frame.firstRoll + frame.secondRoll + frame.thirdRoll;
  }

  getRawScore(frame: Frame): number {
    return frame.firstRoll + frame.secondRoll;
  }

  populateGames(): void {
    var gameIds = this.frames.map((frame) => frame.bowlingGameId);

    var uniqueIds = gameIds.filter((v, i, a) => a.indexOf(v) === i);

    for (let i = 0; i < uniqueIds.length; i++) {
      const game: Game = {
        id: uniqueIds[i],
        frames: this.frames.filter(
          (frame) => frame.bowlingGameId === uniqueIds[i]
        ),
        score: this.getTotalScore(
          this.frames.filter((frame) => frame.bowlingGameId === uniqueIds[i])
        ),
      };
      this.games.push(game);
    }
  }

  getTotalScore(frames: Frame[]) {
    return frames
      .map((data) => data.score)
      .reduce((acc, value) => acc + value, 0);
  }
}
