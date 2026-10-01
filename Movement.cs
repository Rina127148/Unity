using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	public Rigidbody rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		// скрипт срабатывает единожды при запуске игрового режима. Получаем доступ к компоненту для "толкания" машины
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		// управление автомобиля - WASD

		// Последовательно расскоментируйте строки реализаций управления, определите разницу
		MovementV1(); 
		// MovementV2();
		// MovementV3();
		// MovementV4();
    }

	void MovementV1()
	{
		float direction = 0f;

		// опрашиваем клавиатуру - была ли нажата клавиша W
		if (Keyboard.current.wKey.isPressed)
		{
			// направление движение - вперед
			direction = 1f;
		}

		// снова опрашиваем клавиатуру - была ли нажата клавиша S
		if (Keyboard.current.sKey.isPressed)
		{
			// направление движение - назад
			direction = -1f;
		}

		if (direction != 0f)
		{
			// определяем итоговое значение скорости, умножая на "мощность машины" (при изменени константы скорость будет разной)
			float acceleration = direction * 5;

			// прикладываем силу, указывая, в каком направлении двигать машину:
			// двигать прямо машину прямо (т.е. transform.forward вектор, куда смотрит машина - вперед)
			// ForceMode.Acceleration - тип определяемой силы, значимости не имеет. 

			rigidbody.AddForce(transform.forward * acceleration, ForceMode.Acceleration);		
		}

		float rotationDirection = 0f;

		// определяем, в какую сторону будем поворачивать авто, в зависимости от нажатой клавиши
		if (Keyboard.current.aKey.isPressed)
		{
			rotationDirection = -1f;
		}

		if (Keyboard.current.dKey.isPressed)
		{
			rotationDirection = 1f;
		}

		// если мы назначили сторону поворота
		if (rotationDirection != 0f)
		{
			// определяем угол поворта, умножая на постоянную величину (10 - можете ее изменять)
			float rotationAngle = rotationDirection * 30 * Time.deltaTime;

			// "поверни машину относительно ее текущего вращения на угол по оси Y"
			rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(0, rotationAngle, 0));
		}
	}

	void MovementV2()
	{
		float direction = 0f;

		// опрашиваем клавиатуру - была ли нажата клавиша W
		if (Keyboard.current.wKey.isPressed)
		{
			// направление движение - вперед
			direction = 1f;
		}

		// снова опрашиваем клавиатуру - была ли нажата клавиша S
		if (Keyboard.current.sKey.isPressed)
		{
			// направление движение - назад
			direction = -1f;
		}

		if (direction != 0f)
		{
			// определяем итоговое значение скорости, умножая на "мощность машины" (при изменени константы скорость будет разной)
			float acceleration = direction * 5;

			// прикладываем силу, указывая, в каком направлении двигать машину:
			// двигать прямо машину прямо (т.е. transform.forward вектор, куда смотрит машина - вперед)
			// ForceMode.Acceleration - тип определяемой силы, значимости не имеет. 

			rigidbody.AddForce(transform.forward * acceleration, ForceMode.Acceleration);		
		}

		// если машина не стоит на месте, то можем "повернуть" ее - узнаем это через продольную скорость физ. компонента, 
		// если она больше 0.5 км/ч, то можем поворачивать машину
		if (rigidbody.linearVelocity.magnitude > 0.5)
		{		
			float rotationDirection = 0f;

			// определяем, в какую сторону будем поворачивать авто, в зависимости от нажатой клавиши
			if (Keyboard.current.aKey.isPressed)
			{
				rotationDirection = -1f;
			}

			if (Keyboard.current.dKey.isPressed)
			{
				rotationDirection = 1f;
			}

			// если мы назначили сторону поворота
			if (rotationDirection != 0f)
			{
				// определяем угол поворта, умножая на постоянную величину (10 - можете ее изменять)
				float rotationAngle = rotationDirection * 30 * Time.deltaTime;

				// "поверни машину относительно ее текущего вращения на угол по оси Y"
				rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(0, rotationAngle, 0));
			}
		}
	}

	void MovementV3()
	{
		float direction = 0f;

		// опрашиваем клавиатуру - была ли нажата клавиша W
		if (Keyboard.current.wKey.isPressed)
		{
			// направление движение - вперед
			direction = 1f;
		}

		// снова опрашиваем клавиатуру - была ли нажата клавиша S
		if (Keyboard.current.sKey.isPressed)
		{
			// направление движение - назад
			direction = -1f;
		}

		if (direction != 0f)
		{
			// определяем итоговое значение скорости, умножая на "мощность машины" (при изменени константы скорость будет разной)
			float acceleration = direction * 5;

			// прикладываем силу, указывая, в каком направлении двигать машину:
			// двигать прямо машину прямо (т.е. transform.forward вектор, куда смотрит машина - вперед)
			// ForceMode.Acceleration - тип определяемой силы, значимости не имеет. 

			rigidbody.AddForce(transform.forward * acceleration, ForceMode.Acceleration);		
		}

		// если машина не стоит на месте, то можем "повернуть" ее - узнаем это через продольную скорость физ. компонента, 
		// если она больше 0.5 км/ч, то можем поворачивать машину
		if (rigidbody.linearVelocity.magnitude > 0.1)
		{		
			float rotationDirection = 0f;

			// определяем, в какую сторону будем поворачивать авто, в зависимости от нажатой клавиши
			if (Keyboard.current.aKey.isPressed)
			{
				rotationDirection = -1f;
			}

			if (Keyboard.current.dKey.isPressed)
			{
				rotationDirection = 1f;
			}

			// если мы назначили сторону поворота
			if (rotationDirection != 0f)
			{
				// инвертируем вращение автомобиля, если мы едем назад!
				if (Keyboard.current.sKey.isPressed)
				{
					rotationDirection = rotationDirection * -1f;
				}

				// определяем угол поворта, умножая на постоянную величину (10 - можете ее изменять)
				float rotationAngle = rotationDirection * 30 * Time.deltaTime;

				// "поверни машину относительно ее текущего вращения на угол по оси Y"
				rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(0, rotationAngle, 0));
			}
		}
	}

	void MovementV4()
	{
		float direction = 0f;

		// опрашиваем клавиатуру - была ли нажата клавиша W
		if (Keyboard.current.wKey.isPressed)
		{
			// направление движение - вперед
			direction = 1f;
		}

		// снова опрашиваем клавиатуру - была ли нажата клавиша S
		if (Keyboard.current.sKey.isPressed)
		{
			// направление движение - назад
			direction = -1f;
		}

		if (direction != 0f)
		{
			// определяем итоговое значение скорости, умножая на "мощность машины" (при изменени константы скорость будет разной)
			float acceleration = direction * 5;

			// прикладываем силу, указывая, в каком направлении двигать машину:
			// двигать прямо машину прямо (т.е. transform.forward вектор, куда смотрит машина - вперед)
			// ForceMode.Acceleration - тип определяемой силы, значимости не имеет. 

			rigidbody.AddForce(transform.forward * acceleration, ForceMode.Acceleration);		
		}

		// если машина не стоит на месте, то можем "повернуть" ее - узнаем это через продольную скорость физ. компонента, 
		// если она больше 0.5 км/ч, то можем поворачивать машину
		if (rigidbody.linearVelocity.magnitude > 0.1)
		{		
			float rotationDirection = 0f;

			// определяем, в какую сторону будем поворачивать авто, в зависимости от нажатой клавиши
			if (Keyboard.current.aKey.isPressed)
			{
				rotationDirection = -1f;
			}

			if (Keyboard.current.dKey.isPressed)
			{
				rotationDirection = 1f;
			}

			// если мы назначили сторону поворота
			if (rotationDirection != 0f)
			{
				// правильно определяем через векторное произведение, куда едет машина:
				// transform.forward - взгляд машины вперед
				// rigidbogy.linearVelocity - 
				// если произведение векторов меньше 0, то машина движется назад
				if (Vector3.Dot(transform.forward, rigidbody.linearVelocity) < 0)
				{
					// и инвертируем
					rotationDirection = rotationDirection * -1f;
				}

				// определяем угол поворта, умножая на постоянную величину (10 - можете ее изменять)
				float rotationAngle = rotationDirection * 30 * Time.deltaTime;

				// "поверни машину относительно ее текущего вращения на угол по оси Y"
				rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(0, rotationAngle, 0));
			}
		}
	}
}
