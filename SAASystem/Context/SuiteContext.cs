using SAASystem.Helper;
using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class SuiteContext : ISuiteContext
    {
        private readonly IMySqlHelper _mySqlHelper;
        public SuiteContext(IMySqlHelper mySqlHelper)
        {
            _mySqlHelper = mySqlHelper;
        }
        public int Delete(int suiteId)
        {
            string query = "DELETE FROM suite WHERE where suite_id = @suite_id";
            object param = new { suite_id = suiteId };
            return _mySqlHelper.Delete(query, param);
        }
        
        public int Insert(string name, double cpw, double size, double securityDeposit, int daysAvailable,
            DateTime contractFrom, DateTime contractTo, int maximumStay, int isShortTermLet, int isAmneties,
            int isFurnish, int isReference, int isBills, int isBroadband)
        {
            string query = "INSERT INTO user (name, cpw, size, security_deposit, days_available Days, datetime_contract_from, datetime_contract_to," +
                " maximum_stay, is_short_term_let, is_amenities, is_furnish, is_reference, is_bills, is_broadband)" +
                " values (@name, @cpw, @size, @security_deposit, @days_available Days, @datetime_contract_from, @datetime_contract_to," +
                " @maximum_stay, @is_short_term_let, @is_amenities, @is_furnish, @is_reference, @is_bills, @is_broadband)";
            object param = new
            {
                name = name,
                cpw = cpw,
                size = size,
                security_deposit = securityDeposit,
                days_available = daysAvailable,
                contract_from = _mySqlHelper.ConvertDateTimeToString(contractFrom),
                contract_to = _mySqlHelper.ConvertDateTimeToString(contractTo),
                maximum_stay = maximumStay,
                is_short_term_let = isShortTermLet,
                is_amneties = isAmneties,
                is_furnish = isFurnish,
                is_reference = isReference,
                is_bills = isBills,
                is_broadband = isBroadband
            };
            return _mySqlHelper.Insert(query, param);
        }

        public SuiteModel Select(int suiteId)
        {
            string query = "SELECT suite_id SuiteId, name Name, cpw Cpw, size Size, security_deposit SecurityDeposit," +
                " days_available Days AvailableDays, datetime_contract_from ContractFrom, datetime_contract_to ContractTo," +
                " maximum_stay MaximumStay, is_short_term_let IsShortTermLet, is_amenities IsAmneties, is_furnish IsFurnish," +
                " is_reference IsReference, is_bills IsBills, is_broadband FROM suite WHERE where suite_id = @suite_id";
            object param = new { suite_id = suiteId };
            return _mySqlHelper.Select<SuiteModel>(query, param);
        }
        public IEnumerable<SuiteModel> SelectAll()
        {
            string query = "SELECT suite_id SuiteId, name Name, cpw Cpw, size Size, security_deposit SecurityDeposit," +
                " days_available Days AvailableDays, datetime_contract_from ContractFrom, datetime_contract_to ContractTo," +
                " maximum_stay MaximumStay, is_short_term_let IsShortTermLet, is_amenities IsAmneties, is_furnish IsFurnish," +
                " is_reference IsReference, is_bills IsBills, is_broadband FROM user";
            return _mySqlHelper.SelectAll<SuiteModel>(query);
        }
        //public int Update(int userId, string username)
        //{
        //    string query = "UPDATE user SET username = @username WHERE user_id IN (@user_id)";
        //    object param = new { user_id = userId, username = username };
        //    return _mySqlHelper.Update(query, param);
        //}
    }
}