/*
Troy's notes

# Gameplay Manager
- Wave spawner
- Pathfinding on enemies
- Prefabs for enemies & stats
- Attackable obstacles (gates, blockades, etc.)


# Tooltip
- Fix background stretch/shrink
- Fix padding for text


# Game
- Camera settings/angle/etc.
- Game loop
- Main Menu


# Other
- HP bars (visisble to camera)
- Spell list
- Clean code using spell list
- Refactor with gets/sets


# Animations

*/

/*
 * 
 * public interface IAnimal {
  string Name { get; }
  
  //void Sleep(int amountOfTime);
}

public interface IHousePet {
  string NickName { get; }
}


public class Animal : IAnimal {
  public Name { get; private set; }
  
  public void Sleep(int amountOfTime){
    Thread.Sleep(amountOfTime);
  }
}


public class Dog : Animal {
  public void Bark(){
    //
  }
}

public class Cat : DickAnimal, IHousePet, IAnimal {
  public string NickName { get; private set; }
}

Dog myDog = new Dog();
myDog.Name = "Banana";
myDog.Bark();

print(myDog.Name);//= Banana

Animal myPet = (Animal)myDog;
myPet.Bark()//Error
  
Cat myCat = new Cat();
myCat.Name = "Banana";

(IHousePet)myCat;
(IAnimal)myCat;
(Animal)myCat;


public interface ISpells {
  
}

public class Spells : ISpells {
  
}


public interface IElementDamage {
	void DoDamage(Target target);
}

public abstract class ElementDamage : IElementDamage {
  protected int myDamage;
  
  protected void ApplyDamage(Target target){
    target.HP -= myDamage;
  }
  
  public abstract void DoDamage(Target target);
}

public class FireBall : FireBolt, IElementDamage {
  	public void DoDamage(Target target){
      target.HP -= 5;
    }
  
    public void DotTick(){
      //Banana
    }
}

public class FrostBolt : FrostAttack, IElementDamage {
  	public void DoDamage(Target target){
      target.HP -= 2;
    }
  
  	public void DoSlow(){
      //
    }
}

public class LightningBolt : ElementDamage {
  	public LightningBolt(int damageAmount){
      myDamage = damageAmount;
    }
  
  	public void DoDamage(Target target){
      ApplyDamage(target);
    }
}

public class ElementTurret {
  public IElementDamage currentElement;
  
  public virtual void ShootTarget(Target target){
    currentElement.DoDamage(target);
  }
}

public class RotatingElementTurret : ElementTurret {
  protected IElementDamage[] myElements = new IElementDamage[] {new FireBall(), new FrostBolt(), new LightningBolt(7)};
  protected int currentElementIndex = 0;
  
  public RotatingElementTurret(){
    RotateElements();
  }
  
  public void RotateElements(){
    currentElementIndex = (currentElementIndex + 1) % myElements.length;
    currentElement = myElements[currentElementIndex];
  }
  
  public override void ShootTarget(Target target){
    //currentElement.DoDamage(target);
    base.ShootTarget(target);
    RotateElements();
  }
}


public class OldElementTurret{
  public FrostBolt frostElement;
  public FireBall fireElement;
  public LightningBolt lightningElement;
  
  public void ShootTarget(Target target){
    if(frostElement != null){
      frostElement.DoDamage(target);
    }else if (fireElement != null){
      fireElement.DoDamage(target);
    } else {
      lightningElement.DoDamage(target);
    }
  }
}

Target Dave = new Target();

ElementTurret myTurret = new ElementTurret();
myTurret.currentElement = new FireBall();

myTurret.ShootTarget(Dave);
*/