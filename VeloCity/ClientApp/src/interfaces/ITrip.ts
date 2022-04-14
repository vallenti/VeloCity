export interface ITrip {
  id: number;
  start: Date;
  end: Date | undefined;
  user: string;
  bikeId: number;
  totalAmount: number;
  totalMinutes: number;
}
