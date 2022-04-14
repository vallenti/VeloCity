export interface IStation {
  id: number;
  name: string;
  capacity: number;
  latitude: number;
  longitude: number;
  updatedAt: Date | undefined;
  parkedBikesCount: number;
  availableBikes: number;
}
