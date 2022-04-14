export interface IMarker {
  position: { lat: number, lng: number },
  label: { color: string, text: string },
  title: string,
  options: { animation: number }
}
