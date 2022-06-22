export interface Frame {
  userId: number;
  bowlingGameId: number;
  frameNumber: number;
  firstRoll: number;
  secondRoll: number;
  thirdRoll: number;
  isStrike: boolean;
  isSpare: boolean;
  score: number;
  bonusPoints: number;
}
