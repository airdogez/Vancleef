sources := $(wildcard *.md)
objects := $(sources:%.md=%.pdf)

all: $(objects)

%.pdf : %.md
	pandoc -s $< -o $@

clean:
	rm *.pdf
