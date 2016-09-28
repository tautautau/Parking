namespace Parking.Infrastructure

type Event(version: int) =
    let version = version 
    interface IMessage