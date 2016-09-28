namespace Parking.Infrastructure

type IBus =
    abstract member Send: Command -> unit
    abstract member Publish: Event -> unit