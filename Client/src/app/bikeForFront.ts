export class BikeForFront {
  constructor(
      public id?: number,
      public title?: string,
      public type?: Type,
      public price?: number) { }
}

enum Type{
    Road = 0,
    Mountain = 1
}
