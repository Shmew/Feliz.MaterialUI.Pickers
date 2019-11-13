namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Feliz
open Feliz.MaterialUI
open System

[<Erase>]
type clockView =
    inherit textField
    /// TimePicker value
    static member inline date (date: DateTime) = Interop.mkAttr "date" date
    /// 12h/24h clock mode
    static member inline ampm (value: bool) = Interop.mkAttr "ampm" value
    /// Minutes step
    static member inline minutesStep (value: int) = Interop.mkAttr "minutesStep" value
    /// Minutes step
    static member inline minutesStep (value: float) = Interop.mkAttr "minutesStep" value
    /// On hour change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onHourChange (handler: DateTime -> unit) = Interop.mkAttr "onHourChange" (Func<_,_> handler)
    /// On hour change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onHourChange (handler: DateTime -> bool -> unit) = Interop.mkAttr "onHourChange" (Func<_,_,_> handler)
    /// On minutes change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onMinutesChange (handler: DateTime -> unit) = Interop.mkAttr "onMinutesChange" (Func<_,_> handler)
    /// On minutes change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onMinutesChange (handler: DateTime -> bool -> unit) = Interop.mkAttr "onMinutesChange" (Func<_,_,_> handler)
    /// On seconds change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onSecondsChange (handler: DateTime -> unit) = Interop.mkAttr "onSecondsChange" (Func<_,_> handler)
    /// On seconds change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onSecondsChange (handler: DateTime -> bool -> unit) = Interop.mkAttr "onSecondsChange" (Func<_,_,_> handler)

module clockView =
    /// Clock type
    [<Erase>]
    type type' =
        static member inline hours = Interop.mkAttr "type" "hours"
        static member inline minutes = Interop.mkAttr "type" "minutes"
        static member inline seconds = Interop.mkAttr "type" "seconds"