namespace Feliz.MaterialUI.Pickers

open System.ComponentModel
open Fable.Core
open Fable.Core.JsInterop

[<EditorBrowsable(EditorBrowsableState.Never)>]
module HookImports =
    /// Returns utils obj
    let useUtils () : Bindings.IDateUtils = import "useUtils" "@material-ui/pickers"

[<Erase>]
type Hooks =
    /// Returns date utility interface
    static member inline useUtils () : Bindings.IDateUtils = HookImports.useUtils()
