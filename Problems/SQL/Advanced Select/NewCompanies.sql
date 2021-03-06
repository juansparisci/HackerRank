-- https://www.hackerrank.com/challenges/the-company/problem

SELECT 
        COMPANY.COMPANY_CODE, FOUNDER, COUNT( DISTINCT LEAD_MANAGER.LEAD_MANAGER_CODE), 
        COUNT(DISTINCT SENIOR_MANAGER.senior_manager_code), COUNT(DISTINCT MANAGER.MANAGER_CODE), 
        COUNT(DISTINCT EMPLOYEE.EMPLOYEE_CODE) 
FROM 
        COMPANY INNER JOIN LEAD_MANAGER ON COMPANY.COMPANY_CODE=LEAD_MANAGER.COMPANY_CODE 
                INNER JOIN SENIOR_MANAGER ON LEAD_MANAGER.lead_manager_code = SENIOR_MANAGER.lead_manager_code 
                                        AND SENIOR_MANAGER.COMPANY_CODE = COMPANY.COMPANY_CODE 
                INNER JOIN  MANAGER ON MANAGER.COMPANY_CODE = COMPANY.COMPANY_CODE 
                                        AND MANAGER.SENIOR_MANAGER_CODE = SENIOR_MANAGER.SENIOR_MANAGER_CODE 
                                        AND MANAGER.LEAD_MANAGER_CODE = LEAD_MANAGER.LEAD_MANAGER_CODE 
                INNER JOIN EMPLOYEE ON EMPLOYEE.COMPANY_CODE = COMPANY.COMPANY_CODE 
                                        AND EMPLOYEE.SENIOR_MANAGER_CODE = SENIOR_MANAGER.SENIOR_MANAGER_CODE 
                                        AND EMPLOYEE.LEAD_MANAGER_CODE = LEAD_MANAGER.LEAD_MANAGER_CODE 
                                        AND EMPLOYEE.MANAGER_CODE = MANAGER.MANAGER_CODE 
GROUP BY COMPANY.COMPANY_CODE, COMPANY.FOUNDER ORDER BY COMPANY.COMPANY_CODE;