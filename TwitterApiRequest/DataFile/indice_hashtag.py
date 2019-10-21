f = open("twitter2.txt", 'r',encoding="utf8")
w = open("indice_id_tweet.txt", 'w' )

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

lista = []
while pLe():
	pass	

w.write("40;10\n")
lista.sort(key = lambda mbr: operator.attrgetter('index')(mbr).lower(),  reverse = True)
w.write(linha.ljust(40) + str('%010d' % pos) + "\n")

f.close
w.close