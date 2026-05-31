# Projeto 3 - Computação Gráfica
Cena 3D interativa em OpenGL com iluminação ambiente, difusa e especular, aplicada a múltiplos objetos texturizados com parâmetros de material individuais.

Dupla:
- Arthur Trottmann Ramos - 14681052
- Maicon Chaves Marques - 14593530

---

## Objetos da Cena

| Objeto | Ambiente | Descrição |
|--------|----------|-----------|
| Barril | Externo | Barril de madeira e ferrugem |
| Cacto01 | Externo | Cacto com flores e espinhos |
| Cacto02 | Externo | Cacto com agave e folhas |
| Cadeira | Interno | Cadeira de madeira |
| Cama | Interno | Cama com colchão |
| Casa | Estrutura | Casa com fachada detalhada |
| Cavalo | Externo | Cavalo com carroça e rodas animadas |
| Céu | Externo | Skybox com textura de céu noturno |
| Chão | Externo | Plano de chão texturizado |
| Jhon (+ Tocha) | Externo | Personagem principal controlável — a **tocha** é a fonte de luz externa (translada junto ao personagem) |
| Lampião | Interno | Lampião metálico com vidro — fonte de luz interna (branca) |
| Mapa | Interno | Mapa do tesouro |
| Mesa | Interno | Mesa de madeira |
| Rifle | Interno | Rifle de madeira e metal |
| Vela | Interno | Vela com chama — fonte de luz interna (vermelha) |

---

## Fontes de Luz

| Fonte | Ambiente | Cor | Tecla |
|-------|----------|-----|-------|
| Tocha (Jhon) | Externo | Branca | `E` |
| Vela | Interno | Vermelha | `R` |
| Lampião | Interno | Branca | `T` |

A tocha translada junto com o personagem Jhon e afeta apenas objetos do ambiente externo. A vela e o lampião afetam apenas objetos do ambiente interno.

---

## Controles

### Câmera
| Tecla | Ação |
|-------|------|
| `W` / `S` | Move a câmera para frente / trás |
| `A` / `D` | Move a câmera para esquerda / direita |
| Mouse | Orienta a direção da câmera |
| Scroll | Zoom (campo de visão) |

### Movimentação do Personagem (Jhon)
| Tecla | Ação |
|-------|------|
| `↑` / `↓` | Move Jhon no eixo X |
| `→` / `←` | Move Jhon no eixo Z |

### Fontes de Luz (Liga/Desliga)
| Tecla | Ação |
|-------|------|
| `E` | Liga / desliga a tocha do Jhon (ambiente externo) |
| `R` | Liga / desliga a vela (ambiente interno) |
| `T` | Liga / desliga o lampião (ambiente interno) |

### Tipos de Iluminação (Liga/Desliga)
| Tecla | Ação |
|-------|------|
| `V` | Liga / desliga iluminação ambiente |
| `B` | Liga / desliga iluminação difusa |
| `N` | Liga / desliga iluminação especular |

### Parâmetros de Material (todos os objetos)
| Tecla | Ação |
|-------|------|
| `Y` | Incrementa brilho especular (Ns) |
| `G` | Decrementa brilho especular (Ns) |
| `U` | Incrementa coeficiente ambiente (Ka) |
| `H` | Decrementa coeficiente ambiente (Ka) |
| `I` | Incrementa reflexão difusa (Kd) |
| `J` | Decrementa reflexão difusa (Kd) |
| `O` | Incrementa reflexão especular (Ks) |
| `K` | Decrementa reflexão especular (Ks) |

### Geral
| Tecla | Ação |
|-------|------|
| `X` | Restaura todos os parâmetros ao estado inicial |
| `ESC` | Fecha a janela |

---

## Iluminação

O modelo de iluminação implementado segue a equação de Phong com três componentes:

- **Ambiente (Ka):** luz global que afeta todos os objetos igualmente.
- **Difusa (Kd):** reflexão dependente do ângulo entre a normal da superfície e a direção da luz.
- **Especular (Ks / Ns):** reflexo brilhante dependente do ângulo entre o observador e a direção de reflexão. `Ns` controla a concentração do brilho.

Cada subobjeto possui seus próprios parâmetros `Ka`, `Kd`, `Ks` e `Ns` definidos diretamente no código, sem uso de arquivos `.mtl`. A iluminação é segregada por ambiente via `environment_id`: a tocha afeta apenas objetos externos (id `2`) e a vela/lampião afetam apenas objetos internos (id `1`). Também há o uso de gl_FrontFacing no fragment_shader.fs.

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
│   ├── JMeTocha/
│   ├── Lampiao/
│   ├── Mapa/
│   ├── Mesa/
│   ├── Rifle/
│   └── Vela/
├── Shaders/
│   ├── shader_s.py
│   ├── vertex_shader.vs
│   └── fragment_shader.fs
└── Trab03CG.ipynb
```

Cada pasta em `Objetos/` contém o arquivo `.obj` e as texturas (`.png`, `.jpg`, `.jpeg`) do respectivo objeto. Os parâmetros de iluminação de cada material são definidos diretamente no notebook.

---

## Como Executar

Abra e execute o notebook `Trab03CG.ipynb` no Jupyter Notebook ou VS Code com o kernel Python configurado. As dependências necessárias (`glfw`, `pyopengl`, `pyglm`, `numpy`, `pillow`) são instaladas automaticamente na primeira célula.
