export interface ITrip {
  id: number;
  start: Date;
  end: Date | undefined;
  userId: string;
  bikeId: number;
  totalAmount: number;
  totalMinutes: number;
}
