namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz
open System

[<Erase>]
type keyboardTimePicker =
    inherit pickerModal
    /// 12h/24h clock mode
    static member inline ampm (value: bool) = Interop.mkAttr "ampm" value
    /// Auto accept date on selection
    static member inline autoOk (value: bool) = Interop.mkAttr "autoOk" value
    /// Disable picker and text field
    static member inline disabled (value: bool) = Interop.mkAttr "disabled" value
    /// Hide toolbar and show only date/time views
    static member inline disableToolbar (value: bool) = Interop.mkAttr "disableToolbar" value
    /// Message displaying in text field, if null passed (doesn't work in keyboard mode)
    static member inline emptyLabel (value: string) = Interop.mkAttr "emptyLabel" value
    /// Format string
    static member inline format (value: string) = Interop.mkAttr "format" value
    /// Date that will be initially highlighted if null was passed
    static member inline initialFocusedDate (value: DateTime) = Interop.mkAttr "initialFocusedDate" value
    /// Props to pass to keyboard input adornment
    static member inline InputAdornmentProps (props: IReactProperty seq) = Interop.mkAttr "InputAdornmentProps" (createObj !!props)
    /// String value for controlling value with pure input string. 
    ///
    /// Overrides value prop
    static member inline inputValue (value: string) = Interop.mkAttr "inputValue" value
    /// Message, appearing when date cannot be parsed
    static member inline invalidDateMessage (value: ReactElement) = Interop.mkAttr "invalidDateMessage" value // string overload? is this valid?
    /// Message, appearing when date cannot be parsed
    static member inline invalidLabel (value: string) = Interop.mkAttr "invalidLabel" value
    /// Props to pass to keyboard adornment button
    static member inline keyboardButtonProps (props: IReactProperty seq) = Interop.mkAttr "KeyboardButtonProps" (createObj !!props)
    /// Icon displaying for open picker button
    static member inline keyboardIcon (value: ReactElement) = Interop.mkAttr "keyboardIcon" value
    /// Dynamic formatter of text field value
    ///
    /// Signature:
    ///
    /// (date: DateIOType, invalidLabel: string) => string
    static member inline labelFunc (handler: DateTime -> string -> string) = Interop.mkAttr "labelFunc" (Func<_,_,_> handler)
    /// Custom mask. Can be used to override generate from format. (e.g. __/__/____ __:__)
    static member inline mask (value: string) = Interop.mkAttr "mask" value
    /// Char string that will be replaced with number (for "_" mask will be "__/__/____")
    static member inline maskChar (value: string) = Interop.mkAttr "maskChar" value
    /// Error message, shown if date is more then maximal date
    static member inline maxDateMessage (value: ReactElement) = Interop.mkAttr "maxDateMessage" value // string overload? is this valid?
    /// Error message, shown if date is less then minimal date
    static member inline minDateMessage (value: ReactElement) = Interop.mkAttr "minDateMessage" value // string overload? is this valid?
    /// Minutes step
    static member inline minutesStep (value: int) = Interop.mkAttr "minutesStep" value
    /// Minutes step
    static member inline minutesStep (value: float) = Interop.mkAttr "minutesStep" value
    /// Callback fired when date is accepted
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void
    static member inline onAccept (handler: DateTime -> unit) = Interop.mkAttr "onAccept" handler
    /// Keyboard onChange
    ///
    /// Signature:
    ///
    /// (date: DateIOType, value?: string | null) => void
    static member inline onChange (handler: DateTime -> string option -> unit) = Interop.mkAttr "onChange" (Func<_,_,_> handler)
    /// On close callback
    ///
    /// Signature:
    ///
    /// () => void
    static member inline onClose (handler: unit -> unit) = Interop.mkAttr "onClose" handler
    /// Callback fired when new error should be displayed (!! This is a side effect. Be careful if you want to rerender the component)
    ///
    /// Signature:
    ///
    /// (error: ReactNode, value: DateIOType) => void
    static member inline onError (handler: ReactElement -> DateTime -> unit) = Interop.mkAttr "onError" handler
    /// On open callback
    ///
    /// Signature:
    ///
    /// () => void
    static member inline onOpen (handler: unit -> unit) = Interop.mkAttr "onOpen" handler
    /// Controlled picker open state
    static member inline open' (value: bool) = Interop.mkAttr "open" value
    /// Popover props passed to material-ui Popover (with variant="inline")
    static member inline popoverProps (popoverProps: IReactProperty seq) = Interop.mkAttr "PopoverProps" (createObj !!popoverProps)
    /// Make picker read only
    static member inline readOnly (value: bool) = Interop.mkAttr "readOnly" value
    /// Refuse values regexp
    static member inline refuse (value: Text.RegularExpressions.Regex) = Interop.mkAttr "refuse" value
    /// Refuse values regexp
    static member inline refuse (value: string) = Interop.mkAttr "refuse" (value |> Text.RegularExpressions.Regex)
    /// Custom renderer for day
    ///
    /// Signature:
    ///
    /// (day: DateIOType, selectedDate: DateIOType, dayInCurrentMonth: boolean, dayComponent: Element) => Element
    static member inline renderDay (render: DateTime -> DateTime -> bool -> ReactElement -> ReactElement) = Interop.mkAttr "renderDay" (Func<_,_,_,_,_> render)
    /// Custom formatter to be passed into Rifm component
    ///
    /// Signature:
    ///
    /// (str: string) => string
    static member inline rifmFormatter (formatter: string -> string) = Interop.mkAttr "renderDay" (Func<_,_> formatter)
    /// Override input component
    static member inline textFieldComponent (value: ReactElementType) = Interop.mkAttr "TextFieldComponent" value
    /// Component that will replace default toolbar renderer
    static member inline toolbarComponent (value: ReactElementType) = Interop.mkAttr "ToolbarComponent" value
    /// Picker value
    static member inline value (value: DateTime) = Interop.mkAttr "value" value
    /// Views to show
    static member inline views (value: #IViewProperty) = Interop.mkAttr "views" (value |> Array.singleton |> ResizeArray)
    /// Views to show
    static member inline views (value: #IViewProperty seq) = Interop.mkAttr "views" (value |> ResizeArray)

module keyboardTimePicker =
    [<Erase>]
    type color = MaterialUI.textField.color 

    [<Erase>]
    type margin = MaterialUI.textField.margin 

    /// Pass material-ui text field variant down, bypass internal variant prop
    [<Erase>]
    type inputVariant =
        static member inline standard = Interop.mkAttr "inputVariant" "standard"
        static member inline outlined = Interop.mkAttr "inputVariant" "outlined"
        static member inline filled = Interop.mkAttr "inputVariant" "filled"

    /// First view to show in DatePicker
    [<Erase>]
    type openTo =
        static member inline hours = Interop.mkAttr "openTo" "hours"
        static member inline minutes = Interop.mkAttr "openTo" "minutes"
        static member inline seconds = Interop.mkAttr "openTo" "seconds"

    /// Force rendering in particular orientation
    [<Erase>]
    type orientation =
        static member inline portrait = Interop.mkAttr "orientation" "portrait"
        static member inline landscape = Interop.mkAttr "orientation" "landscape"

    /// Picker container option
    [<Erase>]
    type variant =
        static member inline dialog = Interop.mkAttr "variant" "dialog"
        static member inline inline' = Interop.mkAttr "variant" "inline"
        static member inline static' = Interop.mkAttr "variant" "static"

    /// Picker view types
    [<Erase>]
    type views =
        static member inline hours : IViewProperty = unbox "hours"
        static member inline minutes : IViewProperty = unbox "minutes"
        static member inline seconds : IViewProperty = unbox "seconds"
