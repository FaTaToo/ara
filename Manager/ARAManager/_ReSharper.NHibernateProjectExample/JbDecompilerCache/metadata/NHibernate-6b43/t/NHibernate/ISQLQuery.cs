// Type: NHibernate.ISQLQuery
// Assembly: NHibernate, Version=3.2.0.4000, Culture=neutral, PublicKeyToken=aa95f207798dfdb4
// Assembly location: D:\_Training\NHibernate\Final\Exercise\Lib\NHibernate 3.2\NHibernate.dll

using NHibernate.Type;

using System;

namespace NHibernate
{
    public interface ISQLQuery : IQuery
    {
        ISQLQuery AddEntity(string entityName);

        ISQLQuery AddEntity(string alias, string entityName);

        ISQLQuery AddEntity(string alias, string entityName, LockMode lockMode);

        ISQLQuery AddEntity(Type entityClass);

        ISQLQuery AddEntity(string alias, Type entityClass);

        ISQLQuery AddEntity(string alias, Type entityClass, LockMode lockMode);

        ISQLQuery AddJoin(string alias, string path);

        ISQLQuery AddJoin(string alias, string path, LockMode lockMode);

        ISQLQuery AddScalar(string columnAlias, IType type);

        ISQLQuery SetResultSetMapping(string name);
    }
}
