import operator
lista = []

f = open("twitter2.txt", 'r')
w = open("indice_screen_name.txt", 'w')

class indiceOff:
	def __init__(self, index, offset):
		self.index = index
		self.offset = offset

def pLe():
	pos = f.tell()
	linha = f.readline()
	if linha == '': return
	linha = linha[609:649]
	linha = linha.strip()
	p = indiceOff(linha, pos)
	lista.append(p)
	return linha


while pLe():
	pass
var = "40;10"
w.write(var.ljust(45) +"\n")
lista.sort(key = lambda mbr: operator.attrgetter('index')(mbr).lower(),  reverse = True)
for x in range (len(lista) - 1):
	w.write((lista[x].index).ljust(40) + str('%010d' % lista[x].offset) + "\n")

f.close
w.close
