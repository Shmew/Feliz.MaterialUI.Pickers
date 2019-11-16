namespace Feliz.MaterialUI.Pickers

module Bindings =
    open System
    open Fable.Core

    [<AllowNullLiteral>]
    type IDateUtils =
        abstract locale: obj option
        abstract moment: obj option
        abstract dayjs: obj option
        abstract yearFormat: string
        abstract yearMonthFormat: string
        abstract dateTime12hFormat: string
        abstract dateTime24hFormat: string
        abstract time12hFormat: string
        abstract time24hFormat: string
        abstract dateFormat: string
        abstract date: ?value: obj -> DateTime option
        abstract parse: value: string * format: string -> DateTime option
        abstract isNull: value: DateTime option -> bool
        abstract isValid: value: obj option -> bool
        abstract getDiff: value: DateTime * comparing: U2<DateTime, string> -> float
        abstract isEqual: value: obj option * comparing: obj option -> bool
        abstract isSameDay: value: DateTime * comparing: DateTime -> bool
        abstract isAfter: value: DateTime * comparing: DateTime -> bool
        abstract isAfterDay: value: DateTime * comparing: DateTime -> bool
        abstract isAfterYear: value: DateTime * comparing: DateTime -> bool
        abstract isBeforeDay: value: DateTime * comparing: DateTime -> bool
        abstract isBeforeYear: value: DateTime * comparing: DateTime -> bool
        abstract isBefore: value: DateTime * comparing: DateTime -> bool
        abstract startOfMonth: value: DateTime -> DateTime
        abstract endOfMonth: value: DateTime -> DateTime
        abstract addDays: value: DateTime * count: float -> DateTime
        abstract startOfDay: value: DateTime -> DateTime
        abstract endOfDay: value: DateTime -> DateTime
        abstract format: value: DateTime * formatString: string -> string
        abstract formatNumber: numberToFormat: string -> string
        abstract getHours: value: DateTime -> float
        abstract setHours: value: DateTime * count: float -> DateTime
        abstract getMinutes: value: DateTime -> float
        abstract setMinutes: value: DateTime * count: float -> DateTime
        abstract getSeconds: value: DateTime -> float
        abstract setSeconds: value: DateTime * count: float -> DateTime
        abstract getMonth: value: DateTime -> float
        abstract setMonth: value: DateTime * count: float -> DateTime
        abstract getNextMonth: value: DateTime -> DateTime
        abstract getPreviousMonth: value: DateTime -> DateTime
        abstract getMonthArray: value: DateTime -> ResizeArray<DateTime>
        abstract getYear: value: DateTime -> float
        abstract setYear: value: DateTime * count: float -> DateTime
        abstract mergeDateAndTime: date: DateTime * time: DateTime -> DateTime
        abstract getWeekdays: unit -> ResizeArray<string>
        abstract getWeekArray: date: DateTime -> ResizeArray<ResizeArray<DateTime>>
        abstract getYearRange: start: DateTime * ``end``: DateTime -> ResizeArray<DateTime>
        abstract getMeridiemText: ampm: U2<string, string> -> string
        abstract getCalendarHeaderText: date: DateTime -> string
        abstract getDatePickerHeaderText: date: DateTime -> string
        abstract getDateTimePickerHeaderText: date: DateTime -> string
        abstract getMonthText: date: DateTime -> string
        abstract getDayText: date: DateTime -> string
        abstract getHourText: date: DateTime * ampm: bool -> string
        abstract getMinuteText: date: DateTime -> string
        abstract getSecondText: date: DateTime -> string
        abstract getYearText: date: DateTime -> string
