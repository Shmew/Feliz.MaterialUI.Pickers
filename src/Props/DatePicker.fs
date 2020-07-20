namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz
open System

[<Erase>]
type datePicker =
    inherit pickerModal
    /// Enables keyboard listener for moving between days in calendar
    static member inline allowKeyboardControl (value: bool) = Interop.mkAttr "allowKeyboardControl" value
    /// To animate scrolling to current year (using scrollIntoView)
    static member inline animateYearScrolling (value: bool) = Interop.mkAttr "animateYearScrolling" value
    /// Auto accept date on selection
    static member inline autoOk (value: bool) = Interop.mkAttr "autoOk" value
    /// Disable picker and text field
    static member inline disabled (value: bool) = Interop.mkAttr "disabled" value
    /// Disable future dates
    static member inline disableFuture (value: bool) = Interop.mkAttr "disableFuture" value
    /// Disable past dates
    static member inline disablePast (value: bool) = Interop.mkAttr "disablePast" value
    /// Hide toolbar and show only date/time views
    static member inline disableToolbar (value: bool) = Interop.mkAttr "disableToolbar" value
    /// Message displaying in text field, if null passed (doesn't work in keyboard mode)
    static member inline emptyLabel (value: string) = Interop.mkAttr "emptyLabel" value
    /// Format string
    static member inline format (value: string) = Interop.mkAttr "format" value
    /// Date that will be initially highlighted if null was passed
    static member inline initialFocusedDate (value: DateTime) = Interop.mkAttr "initialFocusedDate" value
    /// Message, appearing when date cannot be parsed
    static member inline invalidDateMessage (value: ReactElement) = Interop.mkAttr "invalidDateMessage" value
    /// Message, appearing when date cannot be parsed
    static member inline invalidDateMessage (value: string) = Interop.mkAttr "invalidDateMessage" value
    /// Message, appearing when date cannot be parsed
    static member inline invalidLabel (value: string) = Interop.mkAttr "invalidLabel" value
    /// Dynamic formatter of text field value
    ///
    /// Signature:
    ///
    /// (date: DateIOType, invalidLabel: string) => string
    static member inline labelFunc (handler: DateTime option -> string -> string) = Interop.mkAttr "labelFunc" (Func<_,_,_> handler)
    /// Props to pass to left arrow button
    static member inline leftArrowButtonProps (iconButtonProps: IReactProperty seq) = Interop.mkAttr "leftArrowButtonProps" (createObj !!iconButtonProps)
    /// Left arrow icon
    static member inline leftArrowIcon (value: ReactElement) = Interop.mkAttr "leftArrowIcon" value
    /// Custom loading indicator
    static member inline loadingIndicator (value: ReactElement) = Interop.mkAttr "loadingIndicator" value
    /// Max date
    static member inline maxDate (date: DateTime) = Interop.mkAttr "maxDate" date
    /// Error message, shown if date is more then maximal date
    static member inline maxDateMessage (value: ReactElement) = Interop.mkAttr "maxDateMessage" value
    /// Error message, shown if date is more then maximal date
    static member inline maxDateMessage (value: string) = Interop.mkAttr "maxDateMessage" value
    /// Min date
    static member inline minDate (date: DateTime) = Interop.mkAttr "minDate" date
    /// Error message, shown if date is less then minimal date
    static member inline minDateMessage (value: ReactElement) = Interop.mkAttr "minDateMessage" value
    /// Error message, shown if date is less then minimal date
    static member inline minDateMessage (value: string) = Interop.mkAttr "minDateMessage" value
    /// Callback fired when date is accepted
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void
    static member inline onAccept (handler: DateTime option -> unit) = Interop.mkAttr "onAccept" handler
    /// DatePicker onChange
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void
    static member inline onChange (handler: DateTime option -> unit) = Interop.mkAttr "onChange" handler
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
    static member inline onError (handler: ReactElement -> DateTime option -> unit) = Interop.mkAttr "onError" handler
    /// Callback firing on month change. Return promise to render spinner until it is resolved.
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void | Promise<void>
    static member inline onMonthChange (handler: DateTime option -> unit) = Interop.mkAttr "onMonthChange" handler
    /// Callback firing on month change. Return promise to render spinner until it is resolved.
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void | Promise<void>
    static member inline onMonthChange (handler: DateTime option -> JS.Promise<unit>) = Interop.mkAttr "onMonthChange" handler
    /// On open callback
    ///
    /// Signature:
    ///
    /// () => void
    static member inline onOpen (handler: unit -> unit) = Interop.mkAttr "onOpen" handler
    /// Callback firing on year change
    ///
    /// Signature:
    ///
    /// (date: DateIOType) => void
    static member inline onYearChange (handler: DateTime option -> unit) = Interop.mkAttr "onYearChange" handler
    /// Controlled picker open state
    static member inline open' (value: bool) = Interop.mkAttr "open" value
    /// Popover props passed to material-ui Popover (with variant="inline")
    static member inline popoverProps (popoverProps: IReactProperty seq) = Interop.mkAttr "PopoverProps" (createObj !!popoverProps)
    /// Make picker read only
    static member inline readOnly (value: bool) = Interop.mkAttr "readOnly" value
    /// Custom renderer for day
    ///
    /// Signature:
    ///
    /// (day: DateIOType, selectedDate: DateIOType, dayInCurrentMonth: boolean, dayComponent: Element) => Element
    static member inline renderDay (render: DateTime option -> DateTime option -> bool -> ReactElement -> ReactElement) = Interop.mkAttr "renderDay" (Func<_,_,_,_,_> render)
    /// Props to pass to right arrow button
    static member inline rightArrowButtonProps (iconButtonProps: IReactProperty seq) = Interop.mkAttr "rightArrowButtonProps" (createObj !!iconButtonProps)
    /// Right arrow icon
    static member inline rightArrowIcon (value: ReactElement) = Interop.mkAttr "rightArrowIcon" value
    /// Disable specific date
    static member inline shouldDisableDate (handler: DateTime option -> bool) = Interop.mkAttr "shouldDisableDate" handler
    /// Compare dates by the exact timestamp, instead of start/end of date
    static member inline strictCompareDates (value: bool) = Interop.mkAttr "strictCompareDates" value
    /// Override input component
    static member inline textFieldComponent (value: ReactElementType) = Interop.mkAttr "TextFieldComponent" value
    /// Component that will replace default toolbar renderer
    static member inline toolbarComponent (value: ReactElementType) = Interop.mkAttr "ToolbarComponent" value
    /// Picker value
    static member inline value (value: DateTime) = Interop.mkAttr "value" value
    /// Picker value
    static member inline value (value: DateTime option) = Interop.mkAttr "value" (Option.defaultValue (unbox null) value)
    /// Views to show
    static member inline views (value: #IViewProperty) = Interop.mkAttr "views" (value |> Array.singleton |> ResizeArray)
    /// Views to show
    static member inline views (value: #IViewProperty seq) = Interop.mkAttr "views" (value |> ResizeArray)

module datePicker =
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
        static member inline date = Interop.mkAttr "openTo" "date"
        static member inline year = Interop.mkAttr "openTo" "year"
        static member inline month = Interop.mkAttr "openTo" "month"

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
        static member inline date : IViewProperty = unbox "date"
        static member inline year : IViewProperty = unbox "year"
        static member inline month : IViewProperty = unbox "month"
