using Application.Models;
using TechTalk.SpecFlow;

namespace UnitTests;

[Binding]
[Scope(Feature = "Operações em BankAccount")]
public class BankAccountStepDefs
{
    private BankAccount? _bankAccount;
    private BankAccount? _bankAccountRecept;

    [Given(@"um BankAccount com saldo de R\$ (.*)")]
    public void GivenUmBankAccountComSaldoDeR(decimal p0)
    {
        _bankAccount = new BankAccount(123456, 123, (double) p0);
    }

    [When(@"depositar R\$ (.*)")]
    public void WhenDepositarR(double p0)
    {
        _bankAccount?.Deposit(p0);
    }

    [Then(@"o saldo do BankAccount deve ser R\$ (.*)")]
    public void ThenOSaldoDeveSerR(double p0)
    {
        var saldo = _bankAccount?.Balance;
        Assert.Equal(p0, saldo);
    }

    [When(@"retirar R\$ (.*)")]
    public void WhenRetirarR(Decimal p0)
    {
        _bankAccount?.Withdraw((double) p0);
    }

    [Given(@"um BankAccount de destino com saldo de R\$ (.*)")]
    public void GivenUmBankAccountDeDestinoComSaldoDeR(Decimal p0)
    {
        _bankAccountRecept = new BankAccount(123457, 123, (double) p0);
    }

    [When(@"tranferir R\$ (.*) para o BankAccount de destino")]
    public void WhenTranferirRParaOBankAccountDeDestino(Decimal p0)
    {
        _bankAccount?.Transfer(_bankAccountRecept, (double) p0);
    }

    [Then(@"o saldo do BankAccount de destino deve ser R\$ (.*)")]
    public void ThenOSaldoDoBankAccountDeDestinoDeveSerR(Decimal p0)
    {
        Assert.Equal(_bankAccountRecept.Balance, (double) p0);
    }
}