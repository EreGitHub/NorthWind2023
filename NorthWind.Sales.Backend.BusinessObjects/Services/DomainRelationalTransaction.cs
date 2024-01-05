namespace NorthWind.Sales.Backend.BusinessObjects.Services;

internal class DomainRelationalTransaction : IDomainTransaction
{
    //para manejar transaciones distribuidas samos TransactionScope
    //este se encarga de vigilar, coordinar y controlar las transaciones que sucedan en su ambiente
    //En nuestro ambiente de crear orden implica la conexion a la BD northwinDb y en el ambiente tambien esta la conexion a northwindLogsDb
    //todas esas conexiones forman el ambiente que va vigilar el TransactionScope
    TransactionScope TransactionScope;
    public void BeginTransaction()
    {
        //le indicamos que queremos que se maneje como una transacion distribuida 
        //si solo trabajamos con una base de datos no importa el numero de repositorios, por ejmplo si tengo 20 repositorios y solo afecta a una base de datos
        //no es necesario usar eso "TransactionManager.ImplicitDistributedTransactions = true;" por que no es una transacion destribuida
        //pero cuando implicamos mas de una base de datos si es necesario y estamos hablando de BD distribuidas son dos conexiones distintas
        TransactionManager.ImplicitDistributedTransactions = true; //esto solo funciona en WINDOWS
        //este define el inicio del ambiente o el inicio del rango o el inicion del alcanse de la transacion
        //es donde se crea el ambiente de la transacion distribuida
        TransactionScope = new TransactionScope(            
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                //nivel de aislamiento que solo permita leer lo que ya fue confirmado
                IsolationLevel = IsolationLevel.ReadCommitted,
            },
            //permite realizar operaciones asincronas dentro de la transacion
            TransactionScopeAsyncFlowOption.Enabled);
    }

    public void CommitTransaction()
    {
        TransactionScope.Complete();
        Dispose();
    }

    public void Dispose()
    {
        //el "?" significa si tienes un valor asignado intenta hacerle un dispose
        TransactionScope?.Dispose();
    }

    public void RollbackTransaction()
    {
        Dispose();
    }
}
