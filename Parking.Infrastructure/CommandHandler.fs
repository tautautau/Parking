namespace Parking.Infrastructure

    type CommandHandler<'T when 'T :> Command>=
        abstract member Handle: 'T -> unit