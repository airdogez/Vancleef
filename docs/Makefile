sources := $(wildcard *.md)
objects := $(sources:%.md=%.pdf)
output := out

all: $(objects)

%.pdf : %.md
	pandoc -s $< -o $(output)/$@

clean:
	rm $(output)/*.pdf
