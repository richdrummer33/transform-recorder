Records positions of transforms in time (in a csv-like format) that can be read-back and played. See sample scene for example of setup.

mlagents-learn config/trainer_config.yaml --run-id=pballTrainingAdvanced009 --train --load

mlagents-learn config/trainer_config.yaml --run-id=pballTrainingAdvanced008v2 --num-envs=2 --train --load

mlagents-learn  config/trainer_config.yaml --run-id=pballTrainingAdvanced008v2 --num-envs=2 --train --load

mlagents-learn  config/gail_config.yaml --run-id=pballTrainingCuriousDemonstrated001 --train

mlagents-learn  config/trainer_config.yaml --run-id=pballTrainingRecurrentMem001 --train

ml-agents-envs\mlagents\envs

mlagents-learn config/trainer_config.yaml --num-envs=4 --env="ml-agents-envs/mlagents/envs/ML Agent Gordon" --run-id=pballTrainingAdvancedEnvs004 --train