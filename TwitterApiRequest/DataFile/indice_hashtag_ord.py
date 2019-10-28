import operator
f = open("twitter2.txt", 'r')
w = open("indice2_hashtag_ordenado.txt", 'w' )


class indiceOff:
	def __init__(self, index, offset):
		self.index = index
		self.offset = offset


def pLe():
	pos = f.tell()
	linha = f.readline()
	if linha == '': return
	hashtags = linha[309:589]
	hashtags = hashtags.strip()
	if '#' in hashtags:
		hashtags = hashtags.split('#')
		for x in range(len(hashtags)):
			if(x != 0):
				p = indiceOff(hashtags[x], pos)
				lista.append(p)

	return linha

lista = []
ordendado = []
while pLe():
	pass
var = "280;10"
w.write(var.ljust(290) + "\n")
lista.sort(key = lambda mbr: operator.attrgetter('index')(mbr).lower(), reverse = True)
for x in range (len(lista)):
	w.write((lista[x].index).ljust(279)+ " " + str('%010d' % lista[x].offset) + "\n")
