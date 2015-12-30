from lxml import html
import requests

page = requests.get('http://www.bathnes.gov.uk/publicartcatalogue/detail/1')
tree = html.fromstring(page.content)

#This will create a list of buyers:
rows = tree.xpath('//div[@class="pubart"]/table[@class="bottombordertable"]/tr')
#This will create a list of prices


for row in rows:
    print 'Row: ', row.xpath('/td')

