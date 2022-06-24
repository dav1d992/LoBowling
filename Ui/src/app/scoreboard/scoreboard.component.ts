import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import { BowlingDog } from '../_dogs/bowling.dog';
import { Frame } from '../_models/frame';
import { Game } from '../_models/game';
import { User } from '../_models/user';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ScoreboardComponent implements OnInit {
  users: User[] = [];
  games: Game[] = [];
  totalScore: number = 0;
  dataSource: Frame[] = [];
  displayedColumns: string[] = [
    'frame',
    'first-roll',
    'second-roll',
    'third-roll',
    'strike',
    'spare',
    'score',
  ];

  constructor(private bowlingDog: BowlingDog, private ref: ChangeDetectorRef) {}

  ngOnInit(): void {
    setInterval(() => {
      if (this.games.length === 0) {
        this.games = this.bowlingDog.games;
      }
      if (this.users.length === 0) {
        this.users = this.bowlingDog.users;
      }
      this.ref.markForCheck();
    }, 1000);
  }

  getUser(game: Game): User | undefined {
    return this.users.find(
      (user) =>
        user.id ===
        game.frames.find((frame) => (frame.bowlingGameId = game.id))?.userId
    );
  }

  isGutterGame(game: Game) {
    return game.score === 0;
  }

  isPerfectGame(game: Game) {
    return game.score === 300;
  }
}
