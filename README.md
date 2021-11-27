# Assignment
Create a Web API with the following functionality. Following with the Methods accordingly.

1. Add an endpoint to get a list of campaigns.
Make a call to external API https://testapi.donatekart.com/api/campaign to fetch the
campaigns and sort them by Total Amount in descending order and return the
campaigns. The result returned should contain the fields Title, Total Amount, Backers
Count and End Date.
**~/api/Campaign/GetSortedListOfCampaigns**


2. Add an endpoint to get active campaigns that are created within the last 1 month.
Make a call to external API https://testapi.donatekart.com/api/campaign to fetch
campaigns and filter active campaigns. A campaign is active if the end date is greater
than or equal to today. Filter the list further to get the campaigns that are created within
the last 30 days.
**~/api/ActiveCampaign/GetListOfActiveCampaigns**


3. Add an endpoint to get closed campaigns.
Make a call to external API https://testapi.donatekart.com/api/campaign to fetch
campaigns and filter closed campaigns. A campaign is closed if the end date is less than
today, or Procured Amount is greater than or equal to the Total Amount.
**~/api/ClosedCampaign/GetListOfClosedCampaigns**


4. Write a query to get the nth highly paid employee of the company.

select * from
(select employeeName, salary, dense_rank() 
over(order by salary desc)r from Employee) 
where r=n;

If n =2, then 2nd highly paid employee,
n=3, 3rd highly paid employee and so on..

