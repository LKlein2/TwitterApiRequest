f = open("twitter2.txt", 'r',encoding="utf8")
w = open("indice.txt", 'w' )

def pLe():
	pos = f.tell()
	linha = f.readline()
	if linha == '': return
	linha = linha[1:20]
	w.write("0" + linha + str('%010d' % pos) + "\n")

	return linha

lista = []
w.write("21;10\n")

while pLe():
	pass	

f.close
w.close