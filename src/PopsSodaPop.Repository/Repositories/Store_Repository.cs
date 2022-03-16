using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Store_Repository
{
    //we need a collection type 
    //we want to use a List<T> -> List<Store>
    //this list will hold all of the stores that we have
    // this list can Add, Remove, Give you a Store (return), or Give user all of the stores 
    // it holds (return)
    //'fake database'
    private readonly List<Store> _storeDatabase = new List<Store>();

    //implement the ID counter
    private int _count = 0;

    //create/add
    public bool AddStoreToDatabase(Store store)
    {
        //is check if the store variable has valid data
        //makes sure that the store is not empty
        if (store != null)
        {
            //increment the counter
            _count++;

            //assign the _count to the store.ID
            store.ID = _count;

            //add the store to the database
            _storeDatabase.Add(store);

            //we will return true for UI purposes
            return true;
        }
        else
        {
            return false;
        }
    }

    //read/ Give user all of the stores (return List<Store>)
    public List<Store> GetAllStores()
    {
        return _storeDatabase;
    }

    //read/ Give you a Store (return Store)
    public Store GetStoreByID(int id)
    {
        foreach (Store store in _storeDatabase)
        {
            if (store.ID == id)
            {
                return store;
            }
        }
        return null;
    }

    //update / COMPLETE CLEARING OF DATA (NOT THE IDs)
    public bool UpdateStoreData(int storeID, Store newStoreData)
    {
        //so find the old store data (existing data in _storeDatabase)
        Store oldStoreData = GetStoreByID(storeID);

        //check if the oldStoreData actually exists
        if (oldStoreData != null) //null is nothing...
        {
            //we write over EVERYTHING except the oldStoreData.ID
            oldStoreData.Name = newStoreData.Name;
            oldStoreData.Employees = newStoreData.Employees;
            oldStoreData.Vendors = newStoreData.Vendors;
            return true;
        }
        else
        {
            return false;
        }

    }

    //delete /remove store from _storeDatabase
    public bool RemoveStoreFromDatabase(int id)
    {
        var store = GetStoreByID(id);
        if (store != null)
        {
            _storeDatabase.Remove(store);
            return true;
        }
        else
        {
            return false;
        }

    }
}
