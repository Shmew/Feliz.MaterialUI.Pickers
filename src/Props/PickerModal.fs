namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI

[<Erase>]
type pickerModal =
    inherit textField
    /// "CANCEL" label message
    static member inline cancelLabel (value: ReactElement) = Interop.mkAttr "cancelLabel" value
    /// "CANCEL" label message
    static member inline cancelLabel (value: string) = Interop.mkAttr "cancelLabel" value
    /// Show clear action in picker dialog
    static member inline clearable (value: bool) = Interop.mkAttr "clearable" value
    /// "CLEAR" label message
    static member inline clearLabel (value: ReactElement) = Interop.mkAttr "clearLabel" value
    /// "CLEAR" label message
    static member inline clearLabel (value: string) = Interop.mkAttr "clearLabel" value
    /// Props to pass to left arrow button
    static member inline dialogProps (dialogProps: IReactProperty seq) = Interop.mkAttr "DialogProps" (createObj !!dialogProps)
    /// "OK" label message
    static member inline okLabel (value: ReactElement) = Interop.mkAttr "okLabel" value
    /// "OK" label message
    static member inline okLabel (value: string) = Interop.mkAttr "okLabel" value
    /// If true today button will be displayed 
    ///
    /// **clear button has higher priority**
    static member inline showTodayButton (value: bool) = Interop.mkAttr "showTodayButton" value
    /// "TODAY" label message
    static member inline todayLabel (value: ReactElement) = Interop.mkAttr "todayLabel" value
    /// "TODAY" label message
    static member inline todayLabel (value: string) = Interop.mkAttr "todayLabel" value

module pickerModal = Feliz.MaterialUI.textField
