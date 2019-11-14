namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Feliz
open Feliz.MaterialUI
open System

[<Erase>]
type timePickerView =
    inherit pickerModal
    /// 12h/24h clock mode
    static member inline ampm (value: bool) = Interop.mkAttr "ampm" value
    /// TimePicker value
    static member inline date (date: DateTime) = Interop.mkAttr "date" date
    /// Minutes step
    static member inline minutesStep (value: int) = Interop.mkAttr "minutesStep" value
    /// Minutes step
    static member inline minutesStep (value: float) = Interop.mkAttr "minutesStep" value
    /// On hour change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onHourChange (handler: DateTime -> unit) = Interop.mkAttr "onHourChange" handler
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
    static member inline onMinutesChange (handler: DateTime -> unit) = Interop.mkAttr "onMinutesChange" handler
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
    static member inline onSecondsChange (handler: DateTime -> unit) = Interop.mkAttr "onSecondsChange" handler
    /// On seconds change
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onSecondsChange (handler: DateTime -> bool -> unit) = Interop.mkAttr "onSecondsChange" (Func<_,_,_> handler)

module timePickerView =
    /// Clock type
    [<Erase>]
    type type' =
        static member inline hours = Interop.mkAttr "type" "hours"
        static member inline minutes = Interop.mkAttr "type" "minutes"
        static member inline seconds = Interop.mkAttr "type" "seconds"