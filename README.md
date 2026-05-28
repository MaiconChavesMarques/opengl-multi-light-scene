# Projeto 2 - Computação Gráfica

Cena 3D interativa em OpenGL com múltiplos objetos texturizados, aplicando transformações geométricas (translação, rotação, escala) via teclado.

Dupla:
- Arthur Trottmann Ramos - 14681052
- Maicon Chaves Marques - 14593530

---

## Objetos da Cena

| Objeto | Descrição |
|--------|-----------|
| Barril | Barril de madeira e ferrugem |
| Cacto01 | Cacto com flores e espinhos |
| Cacto02 | Cacto com agave e folhas |
| Cadeira | Cadeira de madeira |
| Cama | Cama com colchão |
| Casa | Casa com fachada detalhada |
| Cavalo | Cavalo com carroça e rodas animadas |
| Céu | Skybox com textura de céu noturno |
| Chão | Plano de chão texturizado |
| Fogueira | Fogueira com carvão e madeira |
| Jhon | Personagem principal controlável |
| Lampião | Lampião com vidro e corpo metálico |
| Mapa | Mapa do tesouro |
| Mesa | Mesa de madeira |
| Nuvem/Fumaça | Nuvem com escala animada simulando fumaça |
| Rifle | Rifle de madeira e metal |

---

## Controles

### Movimentação do Personagem (Jhon)

| Tecla | Ação |
|-------|------|
| `↑` / `↓` | Move Jhon no eixo X |
| `→` / `←` | Move Jhon no eixo Z |

### Animações

| Tecla | Ação |
|-------|------|
| `F` | Gira as rodas da carroça para frente |
| `G` | Gira as rodas da carroça para trás |
| `+` (Numpad) | Aumenta a escala da fumaça |
| `-` (Numpad) | Diminui a escala da fumaça |

### Seleção e Manipulação de Objetos

| Tecla | Ação |
|-------|------|
| `[` / `]` | Seleciona o objeto anterior / próximo |
| `T` | Modo translação |
| `R` | Modo rotação |
| `O` | Modo escala |
| `X` / `Y` / `Z` | Seleciona o eixo de transformação |
| `↑` / `↓` | Incrementa / decrementa no eixo selecionado |
| `+` / `-` | Dobra / divide o passo de transformação |

### Câmera

| Tecla | Ação |
|-------|------|
| `W` / `S` | Move a câmera para frente / trás |
| `A` / `D` | Move a câmera para esquerda / direita |
| Mouse | Orienta a direção da câmera |
| Scroll | Zoom (campo de visão) |

### Geral

| Tecla | Ação |
|-------|------|
| `P` | Alterna entre modo sólido e wireframe |
| `ESC` | Fecha a janela |

---

## Estrutura do Projeto

```
├── Objetos/
│   ├── Barril/
│   ├── Cacto01/
│   ├── Cacto02/
│   ├── Cadeira/
│   ├── Cama/
│   ├── Casa/
│   ├── Cavalo/
│   ├── Ceu/
│   ├── Chao/
│   ├── Fogueira/
│   ├── Jhon/
│   ├── Lampiao/
│   ├── Mapa/
│   ├── Mesa/
│   ├── Nuvem/
│   └── Rifle/
└── Trab02CG.ipynb
```

Cada pasta contém o arquivo `.obj`, `.mtl` e as texturas (`.png`, `.jpg`, `.jpeg`) do respectivo objeto.

---

## Como Executar

Abra e execute o notebook `Trab02CG.ipynb` no Jupyter Notebook ou VS Code com o kernel Python configurado.
