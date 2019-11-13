namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI

[<Erase>]
type pickerModal =
    inherit textField
    /// "CANCEL" label message
    static member inline cancelLabel (value: ReactElement) = Interop.mkAttr "cancelLabel" value // string overload? is this valid?
    /// Show clear action in picker dialog
    static member inline clearable (value: bool) = Interop.mkAttr "clearable" value
    /// "CLEAR" label message
    static member inline clearLabel (value: ReactElement) = Interop.mkAttr "clearLabel" value // string overload? is this valid?
    /// Props to pass to left arrow button
    static member inline dialogProps (dialogProps: #IReactProperty seq) = Interop.mkAttr "DialogProps" (createObj !!dialogProps)
    /// "OK" label message
    static member inline okLabel (value: ReactElement) = Interop.mkAttr "okLabel" value // string overload? is this valid?
    /// If true today button will be displayed 
    ///
    /// **clear button has higher priority**
    static member inline showTodayButton (value: bool) = Interop.mkAttr "showTodayButton" value
    /// "TODAY" label message
    static member inline todayLabel (value: ReactElement) = Interop.mkAttr "todayLabel" value
