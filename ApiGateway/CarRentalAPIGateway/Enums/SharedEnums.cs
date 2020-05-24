namespace CarRentalAPIGateway.Enums
{
    public enum UserRole
    {

        Admin = 1,
        Customer,
        None
    }

    public enum ReservationStatus
    {
        Active = 1,
        Cancelled,
        Ended,
        None
    }

    public enum Currencies
    {
        USD = 0,
        JPY,
        BGN,
        CZN,
        DKK,
        GBP,
        HUF,
        PLN,
        RON,
        SEK,
        CHF,
        ISK,
        NOK,
        HRK,
        RUB,
        TRY,
        AUD,
        BRL,
        CAD,
        CNY,
        HKD,
        IDR,
        ILS,
        INR,
        KRW,
        MXN,
        MYR,
        NZD,
        PHP,
        SGD,
        THB,
        ZAR
    }
}
