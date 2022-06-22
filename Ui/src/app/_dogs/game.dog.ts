import { Injectable } from '@angular/core';
import { Frame } from '../_models/frame';
import { FrameService } from '../_services/frame.service';

@Injectable({
  providedIn: 'root',
})
export class GameDog {
  public games: Frame[] = [];

  constructor(private frameService: FrameService) {
    this.frameService.getFrames().subscribe({
      next: (res: Frame[]) => {
        for (let frameIndex = 0; frameIndex < res.length; frameIndex++) {
          this.frames[frameIndex] = res[frameIndex];
          this.frames[frameIndex].isStrike = this.isStrike(res[frameIndex]);
          this.frames[frameIndex].isSpare = this.isSpare(res[frameIndex]);
        }
      },
      complete: () => {
        this.calculateBonusPoints();
        this.calculateScores();
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
      if (this.frames[i].isStrike) {
        if (this.frames[i].frameNumber === 9) {
          this.frames[i].bonusPoints = this.getRawScore(this.frames[i + 1]);
        } else if (
          this.frames[i].frameNumber === 10 &&
          this.frames[i].isStrike
        ) {
          this.frames[i].bonusPoints =
            this.frames[i].secondRoll + this.frames[i].thirdRoll;
        } else {
          this.frames[i].bonusPoints =
            this.frames[i + 1].firstRoll + this.frames[i + 1].secondRoll;
        }
      } else if (this.frames[i].isSpare) {
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

  calculateScores(): void {
    for (let frame of this.frames) {
      frame.score = this.getTotalScore(frame);
    }
  }

  getTotalScore(frame: Frame): number {
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
}
