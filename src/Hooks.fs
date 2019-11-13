namespace Feliz.MaterialUI.Pickers

open System.ComponentModel
open Fable.Core
open Fable.Core.JsInterop

[<EditorBrowsable(EditorBrowsableState.Never)>]
module HookImports =
    /// Returns inputProps, wrapperProps, and pickerProps
    let useKeyboardPickerState props options : obj = import "useKeyboardPickerState" "@material-ui/pickers"
    /// Returns inputProps, wrapperProps, and pickerProps
    let useStaticState props = import "useStaticState" "@material-ui/pickers"
    /// Returns inputProps, wrapperProps, and pickerProps
    let usePickerState props options = import "usePickerState" "@material-ui/pickers"
    /// Returns utils obj
    let useUtils () : IUtilsProperty = import "useUtils" "@material-ui/pickers"

[<Erase>]
type Hooks =
    static member inline useKeyboardPickerState props options = HookImports.useKeyboardPickerState props options
    static member inline useStaticState props = HookImports.useStaticState props
    static member inline usePickerState props options = HookImports.usePickerState props options
    static member inline useUtils () = HookImports.useUtils()
