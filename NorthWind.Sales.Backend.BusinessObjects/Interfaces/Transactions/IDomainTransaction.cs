namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Transactions;

public interface IDomainTransaction : IDisposable
{
    //estos metodos no son asincronos porque no se necesita que lo sean porque no son de larga duracion
    //todo es en memoria, no necesitamos de devuelvan un TASK, pero podriamos hacerlo si quisieramos

    //nos permitira definir el inicio un bloque de codigo que sera tratado como una transaccion
    void BeginTransaction();
    //nos permitira aceptar los cambios realizados en la transacion
    void CommitTransaction();
    //nos permitira deshacer los cambios realizados en la transacion
    void RollbackTransaction();
}
