namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type pickerUtilsProvider =
    /// The content of the component.
    static member inline children (element: ReactElement) = prop.children element
    /// The content of the component.
    static member inline children (elements: ReactElement seq) = prop.children elements
    /// The content of the component.
    static member inline children (value: string) = Interop.mkAttr "children" value
    /// The content of the component.
    static member inline children (values: string seq) = Interop.mkAttr "children" values
    /// The content of the component.
    static member inline children (value: int) = Interop.mkAttr "children" value
    /// The content of the component.
    static member inline children (value: float) = Interop.mkAttr "children" value
    /// Date locale
    static member inline locale (value: string) = Interop.mkAttr "locale" value
    /// Date locale
    static member inline locale (value: obj) = Interop.mkAttr "locale" value
    
module pickerUtilsProvider =
    /// Date library utility interface to be passed down to pickers
    [<Erase>]
    type utils =
        static member inline dateFns = Interop.mkAttr "utils" (importDefault "@date-io/date-fns")
        static member inline dayjs = Interop.mkAttr "utils" (importDefault "@date-io/dayjs")
        static member inline hijri = Interop.mkAttr "utils" (importDefault "@date-io/hijri")
        static member inline jalaali = Interop.mkAttr "utils" (importDefault "@date-io/jalaali")
        static member inline luxon = Interop.mkAttr "utils" (importDefault "@date-io/luxon")
        static member inline moment = Interop.mkAttr "utils" (importDefault "@date-io/moment")
