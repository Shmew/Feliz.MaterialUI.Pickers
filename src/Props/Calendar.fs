namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI
open System

[<Erase>]
type calendar =
    inherit textField
    /// Enables keyboard listener for moving between days in calendar.
    static member inline allowKeyboardControl (value: bool) = Interop.mkAttr "allowKeyboardControl" value
    /// Calendar Date
    static member inline date (date: DateTime) = Interop.mkAttr "date" date
    /// Disable future dates
    static member inline disableFuture (value: bool) = Interop.mkAttr "disableFuture" value
    /// Disable past dates
    static member inline disablePast (value: bool) = Interop.mkAttr "disablePast" value
    /// Props to pass to left arrow button
    static member inline leftArrowButtonProps (iconButtonProps: #IReactProperty seq) = Interop.mkAttr "leftArrowButtonProps" (createObj !!iconButtonProps)
    /// Left arrow icon
    static member inline leftArrowIcon (value: ReactElement) = Interop.mkAttr "leftArrowIcon" value
    /// Custom loading indicator
    static member inline loadingIndicator (value: ReactElement) = Interop.mkAttr "loadingIndicator" value
    /// Max date
    static member inline maxDate (date: DateTime) = Interop.mkAttr "maxDate" date
    /// Min date
    static member inline minDate (date: DateTime) = Interop.mkAttr "minDate" date
    /// Calendar onChange
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onChange (handler: DateTime -> unit) = Interop.mkAttr "onChange" (Func<_,_> handler)
    /// Calendar onChange
    ///
    /// Signature:
    ///
    /// (date: any, isFinish?: boolean) => void
    static member inline onChange (handler: DateTime -> bool -> unit) = Interop.mkAttr "onChange" (Func<_,_,_> handler)
    /// Callback firing on month change. Return promise to render spinner until it is resolved.
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void | Promise<void>
    static member inline onMonthChange (handler: DateTime -> unit) = Interop.mkAttr "onMonthChange" (Func<_,_> handler)
    /// Callback firing on month change. Return promise to render spinner until it is resolved.
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void | Promise<void>
    static member inline onMonthChange (handler: DateTime -> JS.Promise<unit>) = Interop.mkAttr "onMonthChange" (Func<_,_> handler)
    /// Custom renderer for day
    ///
    /// Signature:
    ///
    /// (day: DateIOType, selectedDate: DateIOType, dayInCurrentMonth: boolean, dayComponent: Element) => Element
    static member inline renderDay (render: DateTime -> DateTime -> bool -> ReactElement -> ReactElement) = Interop.mkAttr "renderDay" (Func<_,_,_,_,_> render)
    /// Props to pass to right arrow button
    static member inline rightArrowButtonProps (iconButtonProps: #IReactProperty seq) = Interop.mkAttr "leftArrowButtonProps" (createObj !!iconButtonProps)
    /// Right arrow icon
    static member inline rightArrowIcon (value: ReactElement) = Interop.mkAttr "rightArrowIcon" value
    /// Disable specific date
    static member inline shouldDisableDate (handler: DateTime -> bool) = Interop.mkAttr "shouldDisableDate" (Func<_,_> handler)
