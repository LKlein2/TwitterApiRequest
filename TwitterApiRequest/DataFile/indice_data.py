import operator
f = open("twitter2.txt", 'r')
w = open("indice_data.txt", 'w' )


class indiceOff:
	def __init__(self, index, offset):
		self.index = index
		self.offset = offset


def pLe():
	pos = f.tell()
	linha = f.readline()
	if linha == '': return
	data = linha[20:28]	
	p = indiceOff(data, pos)
	lista.append(p)	
	return linha

lista = []
ordendado = []
while pLe():
	pass
w.write("08;10             \n")
lista.sort(key=operator.attrgetter('index'))
for x in range (len(lista)):
	w.write(lista[x].index + str('%010d' % lista[x].offset) + "\n")