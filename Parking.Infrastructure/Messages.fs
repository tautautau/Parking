namespace Parking.Infrastructure

module Messages =
    type IMessage = 
        interface end

    type Command() =
        interface IMessage

    type Event(version: int) =
        let version = version 
        interface IMessage

    type IBus =
        abstract member Send: Command -> unit
        abstract member Publish: Event -> unit

    type ICommandHandler<'T when 'T :> Command>=
        abstract member Handle: 'T -> unit               