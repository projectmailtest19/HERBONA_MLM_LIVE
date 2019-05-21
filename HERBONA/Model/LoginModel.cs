﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoanModel
/// </summary>
/// 
public class LoginModel
{
    public string UID { get; set; }
    public string PWD { get; set; }
}

public class ForgotPwdModel
{
    public string UserName { get; set; }
}
public class LoanModel
{
    public LoanModel()
    {

    }
    public string ID { get; set; }
    public string EMP_ID { get; set; }
    public string DESIGNATION { get; set; }
    public string DEPARTMENT_NAME { get; set; }
    public string SALARY { get; set; }
    public string EMP_CODE { get; set; }
    public string SERVICE_DURATION { get; set; }
    public string LOAN_NO { get; set; }
    public string APPLICATION_TYPE { get; set; }
    public string AMOUNT_APPLIED { get; set; }
    public string DESCRIPTION { get; set; }
    public string CONSOLIDATED_SALARY { get; set; }
    public string INTEREST_RATE { get; set; }
    public string NO_OF_INSTALLMENT { get; set; }
    public string INSTALLMENT_AMOUNT { get; set; }
    public string TOTAL_INTEREST { get; set; }
    public string MONTHLY_INTEREST { get; set; }
    public string REJECTION_REASON { get; set; }
    public string AC_APPROVAL { get; set; }
    public string AC_WITH_HOLD { get; set; }
    public string HR_APPROVAL { get; set; }
    public string CEO_APPROVAL { get; set; }
    public string FINALLY_APPROVED { get; set; }
    public string DOJ { get; set; }
    public string AMOUNT_APPROVED { get; set; }
    public string EMPLOYEE_NAME { get; set; }

    public string FOR_MONTHOF { get; set; }
    //public string FINALLY_APPROVED { get; set; }

}


public class loanpayment
{

    public string LOAN_ID { get; set; }
    public string ID { get; set; }
    public string FOR_MONTH { get; set; }
    public string TOTAL_INST_AMT { get; set; }
    public string HR_WITH_HOLD { get; set; }
    public string ISACTIVE { get; set; }
    public string LOAN_NO { get; set; }
    public string INSTALLMENT_AMT { get; set; }
    public string INTEREST_AMT { get; set; }
    public string STATUS { get; set; }
    public string msg { get; set; }
}