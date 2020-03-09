using Realms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioMOBRJ2.DataBase
{
    public class RepositoryListaEstados<TRealmObject> where TRealmObject : RealmObject
    {
        private readonly Realm _currentRealm;

        public RepositoryListaEstados()
        {
            _currentRealm = Realm.GetInstance();
        }

        public void Insert(TRealmObject i)
        {
            using (var transaction = _currentRealm.BeginWrite())
            {
                try
                {
                    _currentRealm.Add(i);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public List<TRealmObject> GetAll()
        {
            return _currentRealm.All<TRealmObject>().ToList();
        }

        public TRealmObject GetById(string id)
        {
            return _currentRealm.Find<TRealmObject>(id);
        }

        public void Remove(string id)
        {
            var realmItem = GetById(id);
            using (var transaction = _currentRealm.BeginWrite())
            {
                try
                {
                    _currentRealm.Remove(realmItem);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}