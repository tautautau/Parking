namespace Parking.Infrastructure

open System

    type AggregateRoot(guid: Guid, version: int) =
        let guid = guid
        let version = version