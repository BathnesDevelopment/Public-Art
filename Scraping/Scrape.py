from bs4 import BeautifulSoup
import requests
import csv

data = []

for i in range(1,175):

	page = requests.get('http://www.bathnes.gov.uk/publicartcatalogue/detail/' + str(i))
	soup = BeautifulSoup(page.content, 'html.parser')
	item = { 'id_number': '', 'title': '', 'artist_name': '', 'type_of_work': '', 'date': '', 'location': '',  'os_map_reference': '',
                 'year_of_unveiling': '', 'unveiling_details': '', 'artist_biography': '', 'artist_dates': '', 'artist_statement': '',
                 'material': '', 'description': '', 'inscription_or_signature': '', 'height': '', 'width': '', 'depth': '', 'diameter': '',
                 'surface_condition': '', 'structural_condition': '', 'commissioned_by': '', 'history_of_the_commission': '', 'style': '',
                 'photograph': '', 'website': '', 'notes': ''}
	
	for row in soup.find_all('tr'):
		if (len(row.find_all('td')) > 1):

			 # Match to the row types we know about.  If match found, add to dictionary.
			if (unicode(row.find_all('td')[0].string).strip() == 'ID Number'):
				item['id_number'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Title'):
				item['title'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Artist Name'):
				item['artist_name'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Type of Work'):
				item['type_of_work'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Date'):
				item['date'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Location'):
				item['location'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'OS Map Reference'):
				item['os_map_reference'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Year of Unveiling'):
				item['year_of_unveiling'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Unveiling Details'):
				item['unveiling_details'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Artist Biography'):
				item['artist_biography'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Artist Dates'):
				item['artist_dates'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Artist Statement'):
				item['artist_statement'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Material'):
				item['material'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Description'):
				item['description'] = row.find_all('td')[1].get_text().strip().encode('utf-8', 'ignore')
			if (unicode(row.find_all('td')[0].string).strip() == 'Inscription or Signature'):
				item['inscription_or_signature'] = row.find_all('td')[1].get_text().strip().encode('utf-8')

			# Measurements
			if (unicode(row.find_all('td')[0].string).strip() == 'Height'):
				item['height'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Width'):
				item['width'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Depth'):
				item['depth'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Diameter'):
				item['diameter'] = row.find_all('td')[1].get_text().strip().encode('utf-8')

			# Condition
			if (unicode(row.find_all('td')[0].string).strip() == 'Surface Condition'):
				item['surface_condition'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Structural Condition'):
				item['structural_condition'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
				
			if (unicode(row.find_all('td')[0].string).strip() == 'Commissioned by'):
				item['commissioned_by'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'History of the commission'):
				item['history_of_the_commission'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Style'):
				item['style'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Photograph'):
				item['photograph'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Website'):
				item['website'] = row.find_all('td')[1].get_text().strip().encode('utf-8')
			if (unicode(row.find_all('td')[0].string).strip() == 'Notes'):
				item['notes'] = row.find_all('td')[1].get_text().strip().encode('utf-8')

			# Record some metadata about the images.

	# Add the item to our dataset
	data.append(item)

print data

# write the data to a JSON file

# write the data to a CSV file
keys = data[0].keys()
with open('public_art_output.csv', 'wb') as output_file:
    dict_writer = csv.DictWriter(output_file, keys)
    dict_writer.writeheader()
    dict_writer.writerows(data)
