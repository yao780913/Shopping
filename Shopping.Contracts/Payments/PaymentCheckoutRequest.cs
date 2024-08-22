namespace Shopping.Contracts.Payments;

public record PaymentCheckoutRequest(Guid CartId, decimal Amount);