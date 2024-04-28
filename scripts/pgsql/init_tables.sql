--环境基础数据
CREATE TABLE IF NOT EXISTS toyar_environment
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    english_name VARCHAR(50) NOT NULL DEFAULT '',
    chines_name VARCHAR(50) NOT NULL DEFAULT '',
    is_system_default BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
                                );
CREATE INDEX idx_toyar_environment_id on toyar_environment (id);
CREATE INDEX idx_toyar_environment_english_name on toyar_environment (english_name);
CREATE INDEX idx_toyar_environment_chines_name on toyar_environment (chines_name);

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('123456789012345678', 'qa', '开发联调环境', true, 'system', '987654321098765435', 'system', '987654321098765435');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('123456789012345679', 'uat', '质量保证环境', true, 'system', '987654321098765435', 'system', '987654321098765435');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('123456789012345680', 'stage', '预发环境', true, 'system', '987654321098765435', 'system', '987654321098765435');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('123456789012345681', 'product', '生产环境', true, 'system', '987654321098765435', 'system', '987654321098765435');

--应用基础数据
CREATE TABLE IF NOT EXISTS toyar_app
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    app_name VARCHAR(50) NOT NULL DEFAULT '',
    module_git VARCHAR(300) NOT NULL DEFAULT '',
    app_type VARCHAR(50) NOT NULL DEFAULT '',
    owned_user VARCHAR(50) NOT NULL DEFAULT '',
    deploy_type  int NOT NULL,
    app_deploy_status_type VARCHAR(50) NOT NULL DEFAULT '',
    note VARCHAR(150) NOT NULL DEFAULT '',
    is_use_deploy_template BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);
CREATE INDEX idx_toyar_app_id on toyar_app (id);
CREATE INDEX idx_toyar_app_app_id on toyar_app (app_id);
CREATE INDEX idx_toyar_app_app_name on toyar_app (app_name);

--角色基础数据
CREATE TABLE IF NOT EXISTS toyar_role
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    english_name VARCHAR(50) NOT NULL DEFAULT '',
    chines_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);
CREATE INDEX idx_toyar_role_id on toyar_role (id);
CREATE INDEX idx_toyar_role_english_name on toyar_role (english_name);
CREATE INDEX idx_toyar_role_chines_name on toyar_role (chines_name);


--应用用户关联关系表
CREATE TABLE IF NOT EXISTS toyar_user_app_relation
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    user_id VARCHAR(50) NOT NULL DEFAULT '',
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);
CREATE INDEX idx_toyar_user_app_relation_user_id on toyar_user_app_relation (user_id);
CREATE INDEX idx_toyar_user_app_relation_app_id on toyar_user_app_relation (app_id);

--用户角色关联关系
CREATE TABLE IF NOT EXISTS toyar_user_role_relation
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    role_id VARCHAR(50) NOT NULL DEFAULT '',
    user_id VARCHAR(50) NOT NULL DEFAULT '',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',  
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_toyar_user_role_relation_role_id on toyar_user_role_relation (role_id);
CREATE INDEX idx_toyar_user_role_relation_user_id on toyar_user_role_relation (user_id);

--用户环境关联关系
CREATE TABLE IF NOT EXISTS toyar_user_environment_relation
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    environment_id VARCHAR(50) NOT NULL DEFAULT '',
    user_id VARCHAR(50) NOT NULL DEFAULT '',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_toyar_user_environment_relation_environment_id on toyar_user_environment_relation (environment_id);
CREATE INDEX idx_toyar_user_environment_relation_user_id on toyar_user_environment_relation (user_id);


