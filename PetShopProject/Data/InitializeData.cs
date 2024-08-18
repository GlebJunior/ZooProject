using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PetShopProject.Models;
using System.IO;

namespace PetShopProject.Data
{
    public class InitializeData
    {
        public string[] animalNames =
        {
            "Catdog",
            "Dragon",
            "Eevee",
            "Godzilla",
            "Huntsman Spider",
            "Mewtwo",
            "Starfish",
            "Pegasus",
            "Pichu",
            "Pikachu",
            "Platypus",
            "Praying Mantis",
            "Red Panda",
            "Stegosaurus",
            "Tyrannosaurus Rex"
        };

        public int[] animalAges =
        {
            13,
            1200,
            40,
            252000000,
            2,
            900,
            34,
            450,
            20,
            35,
            17,
            1,
            23,
            100,
            30
        };
        public List<byte[]> AnimalImages()
        {
            List<byte[]> data = new List<byte[]>();
            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dataImages");

            var imageFiles = Directory.GetFiles(imagesPath).Take(15).ToList();
            foreach (var imageFile in imageFiles)
            {
                using var memoryStream = new MemoryStream();
                using var fileStream = new FileStream(imageFile, FileMode.Open, FileAccess.Read);
                fileStream.CopyTo(memoryStream);
                data.Add(memoryStream.ToArray());
            }

            return data;
        }

        public string[] animalDescriptions =
        {
            "A whimsical hybrid of feline agility and canine loyalty, the Catdog is a curious creature with the playful nature of a cat and the friendly disposition of a dog. It’s often found lounging in the sun one moment and chasing after a ball the next, making it a beloved companion in any household.",
            "Majestic and fearsome, dragons are legendary creatures known for their impressive wingspans and fiery breath. These magnificent beings often inhabit remote mountain ranges or hidden caves, guarding ancient treasures. With scales that shimmer in the sunlight, dragons symbolize power, wisdom, and mystery.",
            "Eevee is a charming and adaptable Pokémon known for its ability to evolve into multiple forms based on its environment. With its large, expressive eyes and fluffy tail, this adorable creature captures hearts wherever it goes. Eevee thrives in various habitats, showcasing its versatility and endearing personality.",
            "A colossal monster that emerged from the depths of the ocean, Godzilla is a symbol of nature's fury. Known for its towering stature and devastating roar, this iconic creature has become a cultural phenomenon. With its reptilian features and immense strength, Godzilla battles against both humans and other monstrous foes like King Kong to protect its territory.",
            "The Huntsman Spider is a large, fast-moving arachnid known for its impressive hunting skills. With its long legs and agile body, it prowls through homes and gardens, capturing insects with ease. Despite its intimidating appearance, the Huntsman Spider is generally harmless to humans and plays a crucial role in controlling pest populations.",
            "A genetically engineered Pokémon with immense psychic powers, Mewtwo is known for its intelligence and complexity. Created from the DNA of the mythical Mew, this powerful being struggles with its identity and purpose. With its sleek, humanoid form and potent abilities, Mewtwo is both a formidable opponent and a misunderstood soul.",
            "Starfish, or sea stars, are fascinating marine creatures known for their star-shaped bodies and ability to regenerate lost limbs. These colorful animals inhabit coral reefs and rocky shorelines, where they feed on mollusks and other small marine life. With their mesmerizing movements, starfish add beauty and diversity to ocean ecosystems. They are also incredibly dumb.",
            "A mythical winged horse, Pegasus represents freedom and inspiration in ancient mythology. With its magnificent wings and striking presence, this legendary creature is often depicted soaring through the skies, symbolizing the heights of creativity and imagination. Pegasus is a beloved figure in literature and art, embodying the spirit of adventure.",
            "Pichu is a small and adorable Pokémon known for its playful nature and electric abilities. With its oversized ears and round body, this little creature is often seen gathering with friends to share in fun and mischief. Despite its small size, Pichu’s potential for evolution into Pikachu makes it a favorite among trainers and fans alike.",
            "Pikachu is a small, yellow rodent-like creature known for its cheerful disposition and electric powers. With its adorable face and signature lightning bolt tail, Pikachu has captured the hearts of fans worldwide. This beloved Pokémon is not only a powerful fighter but also a loyal companion.",
            "The platypus is a unique and fascinating mammal native to Australia, recognized for its duck-bill, webbed feet, and ability to lay eggs. As one of the few venomous mammals, the platypus is a remarkable example of evolutionary adaptation. With a playful demeanor, this semi-aquatic creature enjoys swimming and foraging for insects in freshwater habitats. They also tend to grow up to be successful spies.",
            "The praying mantis is an intriguing insect known for its distinctive posture and predatory behavior. With its triangular head and elongated body, it waits patiently for prey, showcasing remarkable camouflage skills. Often regarded as a symbol of patience and stillness, the praying mantis plays an essential role in controlling pest populations in gardens.",
            "The red panda, a charming and elusive mammal, is known for its striking reddish-brown fur and playful personality. Native to the mountainous regions of Asia, this adorable creature spends most of its time in trees, munching on bamboo and enjoying its surroundings. With its expressive face and gentle nature, the red panda is a favorite among wildlife enthusiasts.",
            "This iconic dinosaur, characterized by its distinctive back plates and spiked tail, roamed the Earth during the Late Jurassic period. The Stegosaurus was a herbivore that used its powerful tail for defense against predators. With a slow but steady gait, this prehistoric giant is often depicted as a gentle giant of its time.",
            "The Tyrannosaurus Rex is one of the most formidable dinosaurs to have ever roamed the Earth. With its massive jaws filled with sharp teeth and powerful legs, this apex predator dominated its environment during the Late Cretaceous period. Often depicted in popular culture as a fierce hunter, the T. Rex embodies strength and dominance in the prehistoric world.",
        };

        public int[] animalCategories =
        {
            1,
            2,
            3,
            2,
            4,
            3,
            5,
            1,
            3,
            3,
            1,
            4,
            1,
            2,
            2
        };

        public string[] categoryNames =
        {
            "Mammal",
            "Reptile",
            "Pokémon",
            "Insect",
            "Aquatic"
        };

        public string[] commentsText =
        {
    "it a cat and a dog but they are one. can it even bark and meow at same time???",
    "Dragons is big lizards and they fly and brethe fire. I think they eat people or something.",
    "Eevee is fluffy and cute and it turn into other pokemons, I like it but I don’t know why.",
    "This dinosaur has spikes on it back, why it need spikes? I want to pet it but I can’t.",
    "Godzilla is giant monster and it smash buildings. I think he is mad all the time.",
    "I seen one and it run really fast! I scream and run away because spiders is scary!",
    "Mewtwo is like super strong and has mind powers? I don’t get how that work but cool!",
    "Starfish is like a star but in water. They don’t swim or walk, how do they live?",
    "Its a horse with wings, so can it fly? I want to ride one but it probably too fast!",
    "Pichu is baby Pikachu I think? Its so tiny and does it even do anything? I dunno.",
    "Pikachu is yellow and it zap people with electricity. Everyone like it but I like others too.",
    "Platypus is weird animal. It has duck face and lays eggs but is a mammal? What?",
    "They look like they praying but they just bugs, do they pray for food or what?",
    "Red panda is cute and fuzzy! I want one but I think they bite or scratch me.",
    "T. rex is big dinosaur with tiny arms. How does it eat? So silly and funny!",
    "The amalgamation of a cat and a dog challenges our understanding of species boundaries, resulting in a fascinating creature that embodies duality.",
    "The dragon, a mythical archetype, represents the untamed forces of nature; its ability to breathe fire symbolizes both destruction and creation.",
    "Eevee epitomizes adaptability in evolutionary biology, with its potential to evolve into various forms depending on environmental conditions—truly a marvel of genetic versatility.",
    "The Stegosaurus, with its distinctive dorsal plates and spiked tail, serves as an intriguing case study in defensive adaptations among herbivorous dinosaurs.",
    "Godzilla symbolizes humanity's existential fears, reflecting our anxieties regarding nuclear power and environmental degradation through its colossal and destructive presence.",
    "The huntsman spider exemplifies the intricacies of arachnid locomotion, showcasing remarkable speed and agility that are essential for predation in diverse habitats.",
    "Mewtwo raises profound ethical questions regarding genetic engineering and artificial intelligence, as it embodies the complexities of creation and autonomy.",
    "The starfish, or sea star, possesses remarkable regenerative capabilities, making it a subject of interest in the fields of biology and medicine for its potential applications in healing.",
    "Pegasus represents the intersection of myth and the human desire for freedom, embodying the aspiration to transcend earthly limitations and explore the heavens.",
    "Pichu, as a pre-evolution of Pikachu, illustrates the concept of growth and development in Pokémon lore, highlighting the importance of nurturing and experience in character progression.",
    "Pikachu, a cultural icon, transcends its status as merely a Pokémon; it serves as a case study in branding and the psychological impact of nostalgia on consumer behavior.",
    "The platypus is a fascinating example of evolutionary convergence, combining characteristics of mammals, reptiles, and birds, thereby challenging conventional classifications in biology.",
    "The praying mantis exhibits complex predatory behaviors, utilizing camouflage and ambush tactics that highlight its role as an apex predator in the insect world.",
    "The red panda, with its striking appearance and elusive nature, plays a crucial role in its ecosystem, serving as an indicator species for biodiversity conservation.",
    "The Tyrannosaurus Rex stands as a testament to the evolutionary arms race, possessing formidable predatory adaptations that underscore the dynamics of survival in prehistoric ecosystems.",
    "Flibberty flobbity doo! Waffle clouds dance in the spaghetti moonlight.",
    "Bubblegum toaster symphonies under the broccoli sun.",
    "Banana shoes wear pajamas in the rainbow toaster.",
    "Flying spaghetti monsters do the cha-cha with jellybeans."
};

        public int[] commentsAnimalIds =
        {
            1,
            2,
            3,
            14,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            15,
            1,
            2,
            3,
            14,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            15,
            1,
            1,
            4,
            4

        };
    }
}
