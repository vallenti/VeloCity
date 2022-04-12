import { IBike } from "./IBike";

export interface IStation {
  id: number;
  name: string;
  capacity: number;
  latitude: number;
  longitude: number;
  updatedAt: Date;
  parkedBikes: IBike[];
}
