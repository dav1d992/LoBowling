import {
  AfterViewInit,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import { FrameDog } from '../_dogs/frame.dog';
import { Frame } from '../_models/frame';
import { Game } from '../_models/game';
import { User } from '../_models/user';
import { FrameService } from '../_services/frame.service';
import { GameService } from '../_services/game.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent implements OnInit {
  users: User[] | undefined;
  games: Game[] = [];
  totalScore: number = 0;
  dataSource: Frame[] = [];
  displayedColumns: string[] = [
    'game',
    'player',
    'frame',
    'first-roll',
    'second-roll',
    'third-roll',
    'strike',
    'spare',
    'score',
  ];

  constructor(private dog: FrameDog, private ref: ChangeDetectorRef) {}

  ngOnInit(): void {
    setInterval(() => {
      if (this.games.length === 0) {
        this.games = this.dog.games;
        console.log(this.games);
      }
      this.ref.markForCheck();
    }, 1000);
  }

  getTotalCost(game: Game) {
    return game.frames
      .map((data) => data.score)
      .reduce((acc, value) => acc + value, 0);
  }
}
