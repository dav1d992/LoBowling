import { Component, OnInit } from '@angular/core';
import { Frame } from '../_models/frame';
import { User } from '../_models/user';
import { FrameService } from '../_services/frame.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  users: User[] | undefined;
  frames: Frame[] | undefined;
  dataSource: any[] = [];
  displayedColumns: string[] = [
    'game',
    'player',
    'frame',
    'first-roll',
    'second-roll',
    'third-roll',
  ];

  constructor(
    private userService: UserService,
    private frameService: FrameService
  ) {}

  ngOnInit(): void {
    this.loadFrames();
  }

  loadFrames() {
    this.frameService.getFrames().subscribe({
      next: (res: Frame[]) => {
        this.frames = res;
        this.dataSource = res;
        console.log('🧵', this.dataSource);
      },
      error: (err) => {
        console.log('Failed to load frames', err);
      },
    });
  }

  loadUsers() {
    this.userService.getUsers().subscribe({
      next: (res: User[]) => {
        this.users = res;
      },
      error: (err) => {
        console.log('Failed to load users', err);
      },
    });
  }
}
