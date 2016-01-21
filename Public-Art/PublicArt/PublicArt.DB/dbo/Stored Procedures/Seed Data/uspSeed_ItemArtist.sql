/*
    Name:           [dbo].[uspSeed_ItemArtist]
    Author:         Chris Pickford
    Created:        2016-01-21
    Description:    Populates table with seed data to be executed post-deployment.
                    Use the following SQL to generate values from a populated table:
                        SELECT N'('
	                        +  'N''' + [Item].[Reference] + ', '
                            +  'N''' + [Artist].[Name]+ ', '
                            +  ISNULL('N''' + REPLACE(CONVERT(NVARCHAR(MAX), [ItemArtist].[Notes]	), '''', '''''') + '''', 'NULL')
	                        + N'),'
                        FROM
                            [dbo].[ItemArtist]
                        INNER JOIN [dbo].[Item]
                            ON [Item].[ItemId] = [ItemArtist].[ItemId]
                        INNER JOIN [dbo].[Artist]
                            ON [Artist].[ArtistId] = [ItemArtist].[ArtistId];
*/

CREATE PROCEDURE [dbo].[uspSeed_ItemArtist]
AS

SET NOCOUNT ON;

MERGE INTO [dbo].[ItemArtist] AS [TARGET]
USING ( SELECT
            [Item].[ItemId]
        ,   [Artist].[ArtistId]
        ,   [VALUES].[Notes]
        FROM (
            VALUES

(N'BA44', N'Sophie White', NULL),
(N'BA70', N'William Pye', NULL),
(N'BA1', N'Jane Lemon', N'design of the St Alphege Triptych'),
(N'BA1', N'Melanie Sproat', N'Copper  Cross'),
(N'BA1', N'The Sarum Group', N'embroidery'),
(N'BA2', N'Melanie Sproat', NULL),
(N'BA3', N'Sue Symons', NULL),
(N'BA4', N'Jane Lemon', NULL),
(N'BA4', N'The Sarum Group', NULL),
(N'BA5', N'Laurence Tindall', NULL),
(N'BA6', N'Leslie Durbin', NULL),
(N'BA7', N'Alex Brogden', NULL),
(N'BA8', N'Jane Lemon', NULL),
(N'BA8', N'The Sarum Group', NULL),
(N'BA9', N'Laurence Beckford', N'production'),
(N'BA9', N'Paul Fletcher', N'design'),
(N'BA10', N'Hugh D. Roberts', NULL),
(N'BA11', N'Mark Angus', NULL),
(N'BA12', N'Fleur Kelly', N'Frescoes'),
(N'BA12', N'John Armstrong', N'Reredos panels'),
(N'BA13', N'Jill Watson', NULL),
(N'BA14', N'Stephen Budd', NULL),
(N'BA15', N'John Neilson', NULL),
(N'BA16', N'Anne Egan', NULL),
(N'BA17', N'Laurence Tindall', NULL),
(N'BA18', N'Mark Angus', NULL),
(N'BA19', N'Sarah Wilson', NULL),
(N'BA21', N'David Backhouse', NULL),
(N'BA23', N'Lee Dickenson', NULL),
(N'BA25', N'Peter Logan', NULL),
(N'BA26', N'Alison Share', NULL),
(N'BA26', N'Carlton Smith', NULL),
(N'BA26', N'Diana O’Keffe', NULL),
(N'BA26', N'Ian Clegg', NULL),
(N'BA26', N'Margaret Withers', N'artistic direction and management '),
(N'BA26', N'Quintin Howard Evans', NULL),
(N'BA27', N'Alec Peever', N'letter cutting'),
(N'BA27', N'Alyson Hallett', N'poem'),
(N'BA28', N'James Elliott', NULL),
(N'BA28', N'Laurence Tindall', NULL),
(N'BA29', N'Hetty Dupays', NULL),
(N'BA30', N'Martin Colbeck', NULL),
(N'BA31', N'Andrew Smith', NULL),
(N'BA32', N'Edwina Bridgeman', N'with the children from the Children Centre'),
(N'BA33', N'Carolyne Kardia', NULL),
(N'BA34', N'Eleanor Glover', N'brush calligraphy'),
(N'BA34', N'Rose Flint', N'poetry'),
(N'BA35', N'Barbara Ash', NULL),
(N'BA36', N'Angela Cockayne', N'and patients from the RUH Children Centre'),
(N'BA37', N'John de Mears', NULL),
(N'BA38', N'City of Bath college stained glass students', NULL),
(N'BA39', N'Angela Cockayne', NULL),
(N'BA39', N'Roz Moorehouse', NULL),
(N'BA40', N'Jim Lowe', NULL),
(N'BA41', N'Liane Tancock', NULL),
(N'BA42', N'Michael Pennie', NULL),
(N'BA43', N'Stephen Magrath', NULL),
(N'BA45', N'Edwina Bridgeman', NULL),
(N'BA46', N'Anna Simmons', NULL),
(N'BA47', N'Ros Ford', NULL),
(N'BA48', N'Julie Starks', NULL),
(N'BA49', N'Ann Scorgie', NULL),
(N'BA50', N'Anna Proctor', NULL),
(N'BA51', N'Neal Tanner Partnership', N'(Architects of St Andrews’ School)'),
(N'BA52', N'David Cox', NULL),
(N'BA53', N'John Potter', NULL),
(N'BA54', N'Meryl Stannard', NULL),
(N'BA56', N'City of Bath College stone mason students', NULL),
(N'BA57', N'Laurence Tindall', NULL),
(N'BA58', N'Anne Egan', N'with the children'),
(N'BA59', N'Laurence Tindall', NULL),
(N'BA60', N'Cleo Mussi', NULL),
(N'BA61', N'Jonathan Cole', NULL),
(N'BA61', N'Ray Smith', NULL),
(N'BA61', N'Tim Horriga', NULL),
(N'BA62', N'Edwina Bridgeman', NULL),
(N'BA63', N'Lesley Kerman', NULL),
(N'BA64', N'Martyn Ware', NULL),
(N'BA65', N'Ray Smith', NULL),
(N'BA66', N'Richard Long', NULL),
(N'BA67', N'Andrew Bolton', NULL),
(N'BA67', N'Steve Porter', N'with the children'),
(N'BA68', N'Neal Tanner Partnership', N'(Architects)'),
(N'BA105', N'Igor Ustinov', NULL),
(N'CM106', N'Jeff Body', NULL),
(N'CM106', N'Peter Osborne', NULL),
(N'BA107', N'Sophie Ryder', NULL),
(N'BA108', N'Robert Race', NULL),
(N'CP110', N'Michael Fairfax', NULL),
(N'BA111', N'John Packer', NULL),
(N'BA111', N'Kevin Hughes', NULL),
(N'BA112', N'Ben Gale', N'of Stoneworks of Bath with poetry by residents of Ladymead House with writer and performer Claire Williamson.'),
(N'BA113', N'Bath Aqua Glass', N'glass insets'),
(N'BA113', N'John Packer', N'bollards'),
(N'BA113', N'Kevin Hughes', N'bollards'),
(N'BA114', N'Nigel Keegan', NULL),
(N'BA114', N'Richard Cooper', NULL),
(N'BA115', N'William Pye', NULL),
(N'BA116', N'Davis, C.E.', N'Conservation by Cliveden Conservation Workshop Ltd in collaboration with JH Consulting Architects'),
(N'BA117', N'William Pye', NULL),
(N'BA118', N'Ben Gale', N'of Stoneworks of Bath'),
(N'BA118', N'Bronwyn Williams Ellis', N'of Old Orchard'),
(N'BA118', N'Peter Linnett', N'of Old Orchard'),
(N'BA119', N'Pat Panton', N'text'),
(N'BA119', N'Paul Cresswell', N'text'),
(N'BA119', N'Peter McLennan', N'incised street markers'),
(N'BA122', N'B. Holden', NULL),
(N'BA122', N'K. Fridrich', NULL),
(N'BA122', N'M. Blow', NULL),
(N'BA122', N'M. Ford', NULL),
(N'BA122', N'N. Rose', NULL),
(N'BA122', N'P. Jennings', NULL),
(N'BA123', N'Adrian Fisher', N'from Minotaur Designs'),
(N'BA123', N'Gilbert Randoll Coate', NULL),
(N'BA124', N'Peter John Wells', NULL),
(N'BA125', N'Edith Massingham', NULL),
(N'BA126', N'Martin Fisher', NULL),
(N'CM128', N'Laurence Tindall', NULL),
(N'K129', N'Anita Andrews', N'and students from local schools'),
(N'K129', N'Liz Fox', NULL),
(N'K130', N'Anita Andrews', N'and members of local organisations including: Avon Meadows Residents Association, Keynsham Potters, Keynsham and Saltford Local History, Age Concern, Keynsham Primary School, St John’s Church Youth Group, Keynsham Community Association.'),
(N'K130', N'Jeremy Attrill', N'Lead artists'),
(N'K130', N'Rosalind Waites', N'Lead artists'),
(N'K131', N'Ray Smith', NULL),
(N'P132', N'Andrew Bolton', N'lead artist'),
(N'P132', N'Mike Burrows', N'poet'),
(N'R133', N'Sebastian Boyesen', NULL),
(N'R134', N'Laurence Tindall', N'with school pupils'),
(N'R135', N'Matthew Body', N'with young people'),
(N'K136', N'Jeff Body', N'with local young people'),
(N'P137', N'Anita Andrews', N'with young people'),
(N'P138', N'Andrew Edleston', N'with young people'),
(N'P138', N'Anita Andrews', NULL),
(N'BA139', N'Andrew Bolton', NULL),
(N'BA139', N'Steve Porter', N'with the children'),
(N'BA140', N'Mel Day', N'with the children'),
(N'BA141', N'Andrew Bolton', NULL),
(N'BA141', N'Steve Porter', N'with the children'),
(N'BA142', N'Mel Day', N'with the school children'),
(N'BA143', N'Rebecca Yeo', N'with the school children'),
(N'BA144', N'Alan Dun', N'pig design and over eighty  artists including Anita Andrews, Anna Gillespie, Peter Blake, Kaffe Fassett, Candace Bahouth, Jane Callan, Charlotte Moore, Julia Trickey, John Gould, Natasha Rampley, Helen Nock, Sonja Benskin-Mesher, Sarah-Jane van der Westhuizen.  Arts departments of local schools and Bath Spa University  were also involved. '),
(N'CP145', N'Jim Partridge', NULL),
(N'CP145', N'Liz Walmsley', NULL),
(N'BA146', N'Peter John Wells', NULL),
(N'BA147', N'Laurence Tindall', NULL),
(N'K148', N'Local young people', NULL),
(N'W149', N'Laurence Tindall', NULL),
(N'K150', N'David Bowers', N'with Keynsham and District Mencap summer play scheme attendants'),
(N'BA151', N'Angela Cockayne', N'Musical Instruments'),
(N'BA151', N'Anita Andrews', N'with the children'),
(N'K152', N'Queens Road Cru', N'with an unknown graffiti artist'),
(N'CP153', N'Vizability Community Art', NULL),
(N'P154', N'David Bowers', N'with the children'),
(N'BA157', N'Richard Sadd', NULL),
(N'BA158', N'Hugh Johnson', NULL),
(N'BA158', N'Richard Sadd', NULL),
(N'BA158', N'Tony Hay', NULL),
(N'BA159', N'Richard Sadd', NULL),
(N'BA159', N'Tony Hay', N'with the service users'),
(N'BA160', N'Kilda Meadows', NULL),
(N'BA161', N'David Bowers', N'and members of the local community'),
(N'BA162', N'Peter Osborne', N'with children visiting the farm'),
(N'K163', N'Lee Dickenson', NULL),
(N'SD165', N'David Bowers', N'with the children'),
(N'CW167', N'Yumiko Aoyagi', NULL),
(N'CW168', N'Jerry Ortmans', NULL),
(N'R170', N'Jeff Body', N'with young people from Radstock'),
(N'BA171', N'Graff’ project ', N'young people for the Walcot Street car park'),
(N'BA172', N'Ray Smith', N'with the children'),
(N'BA173', N'Ray Smith', NULL),
(N'BA174', N'Ray Smith', N'with staff'),
(N'BA175', N'Alex Ramsay', NULL),
(N'BA71', N'Ana Bilankov', NULL),
(N'BA72', N'Anthony Key', NULL),
(N'BA73', N'Bobby Baker', NULL),
(N'BA74', N'Helen Paris', N'(UK)'),
(N'BA74', N'Leslie Hill', N'(USA)'),
(N'BA75', N'Kevin Clifford', N'Dancers include: Emily Dodd from Cornwall, Jane Mason from Devon, Kate Lee from Wiltshire, Louise Brown from Gloucestershire.'),
(N'BA76', N'Deborah Jones', NULL),
(N'BA77', N'Deborah Robinson', NULL),
(N'BA78', N'Fiona Robinson', NULL),
(N'BA79', N'Ingrid Pollard', NULL),
(N'BA80', N'Jane Calow', NULL),
(N'BA81', N'Nick Lowe', NULL),
(N'BA82', N'Stephen Gill', NULL),
(N'BA88', N'Mark Angus', NULL),
(N'BA91', N'Ben Matthews', NULL),
(N'BA92', N'Bernard Adams', NULL),
(N'BA93', N'Arthur Goodwin', NULL),
(N'BA94', N'Jacquie Binns', NULL),
(N'BA95', N'Juliet Hemingray', NULL),
(N'BA96', N'George Lambourn', NULL),
(N'BA97', N'John Morley', NULL),
(N'BA98', N'Lindy Clark', NULL),
(N'BA100', N'Meryl Stannard', NULL),
(N'BA101', N'Piers Ottey', NULL),
(N'BA102', N'Patricia Laing', NULL),
(N'BA103', N'Peter Wright', NULL),
(N'BA104', N'City of Bath College student sculptors', N'Commemorative Column'),
(N'BA104', N'Colin Foster', N'Fish Man'),
(N'BA104', N'Hilary Cartmel', N'Pot of Flowers'),
(N'BA104', N'Janos Kalmar', N'Figure in Space'),
(N'BO127', N'Olga Lehmann', NULL),
(N'BS166', N'David Bowers', NULL),
(N'BA156', N'David Bowers', N'with the children'),
(N'MN164', N'David Bowers', N'with the children'),
(N'CP169', N'Katy Hallett', N'with local school children'),
(N'BA185', N'Chris Williams', NULL),
(N'BA183', N'Vivien Mousdell', NULL),
(N'BA184', N'Ruth Moilliet', NULL),
(N'BA177', N'Barbara Davies', N'designer'),
(N'BA177', N'Yannick Li Ah Kane', N'stone carving and arrangement'),
(N'BA182', N'Nigel Bryant', N'The Pig'),
(N'BA182', N'Stefano Valerio Pieroni', N'King Bladud'),
(N'BA180', N'Alan Dun', N'designer of the lion sculpture. And 100 artists who decorated a lion each. '),
(N'BA181', N'Alec Peever', NULL),
(N'BA181', N'Andy Croft', N'with Combe down residents'),
(N'BA176', N'Barbara Ash', NULL),
(N'BA186', N'Laurence Tindall', NULL),
(N'BA178', N'Henry Haig', NULL),
(N'BA179', N'Jennie Gilling', NULL)

        ) AS [VALUES] ([Reference], [Name], [Notes])
        INNER JOIN [dbo].[Item]
            ON [Item].[Reference] = [VALUES].[Reference]
        INNER JOIN [dbo].[Artist]
            ON [Artist].[Name] = [VALUES].[Name]

) AS [SOURCE] (
    [ItemId]
,   [ArtistId]
,   [Notes]
)
ON [TARGET].[ItemId] = [SOURCE].[ItemId]
AND [TARGET].[ArtistId] = [SOURCE].[ArtistId]

WHEN NOT MATCHED BY TARGET THEN
    INSERT (    
        [ItemId]
    ,   [ArtistId]
    ,   [Notes]
    )
    VALUES (
        [SOURCE].[ItemId]
    ,   [SOURCE].[ArtistId]
    ,   [SOURCE].[Notes]
    )
WHEN MATCHED
AND NOT EXISTS ( SELECT
                    [SOURCE].[ItemId]
                ,   [SOURCE].[ArtistId]
                ,   [SOURCE].[Notes]
                 INTERSECT
                 SELECT
                    [TARGET].[ItemId]
                ,   [TARGET].[ArtistId]
                ,   [TARGET].[Notes]
    ) THEN UPDATE SET
        [Notes]         = [SOURCE].[Notes]
    ,   [ModifiedDate]  = CURRENT_TIMESTAMP;

RETURN 0;