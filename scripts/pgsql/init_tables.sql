--环境基础数据
CREATE TABLE IF NOT EXISTS toyar_environment
(
    id VARCHAR(50) NOT NULL PRIMARY KEY  COMMENT '唯一标识',
    english_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '英文名称',
    chines_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '中文名称',
    is_system_default BOOLEAN NOT NULL DEFAULT false  COMMENT '是否系统默认',
    deleted BOOLEAN NOT NULL DEFAULT false COMMENT '是否删除',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人Id',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人Id',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '最后修改时间',
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '删除时间'
);
CREATE INDEX idx_toyar_environment_id on toyar_environment (id);
CREATE INDEX idx_toyar_environment_english_name on toyar_environment (english_name);
CREATE INDEX idx_toyar_environment_chines_name on toyar_environment (chines_name);

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534535569409', 'qa', '开发联调环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534690758658', 'uat', '质量保证环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534690758659', 'stage', '预发环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534690758660', 'product', '生产环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

--角色基础数据
CREATE TABLE IF NOT EXISTS toyar_role
(
    id VARCHAR(50) NOT NULL PRIMARY KEY  COMMENT '唯一标识',
    english_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '英文名称',
    chines_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '中文名称',
    deleted BOOLEAN NOT NULL DEFAULT false COMMENT '是否删除',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人Id',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人Id',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '最后修改时间',
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '删除时间'
);
CREATE INDEX idx_toyar_role_id on toyar_role (id);
CREATE INDEX idx_toyar_role_english_name on toyar_role (english_name);
CREATE INDEX idx_toyar_role_chines_name on toyar_role (chines_name);

--应用基础数据
CREATE TABLE IF NOT EXISTS toyar_application
(
    id VARCHAR(50) NOT NULL PRIMARY KEY COMMENT '唯一标识',
    app_id VARCHAR(50) NOT NULL DEFAULT ''  COMMENT '应用标识（系统唯一）',
    app_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '应用名称',
    module_git VARCHAR(300) NOT NULL DEFAULT ''  COMMENT 'Git仓库地址',
    app_type VARCHAR(50) NOT NULL DEFAULT '' COMMENT '应用类型',
    owned_user VARCHAR(50) NOT NULL DEFAULT '' COMMENT '应用负责人',
    instance_type  int NOT NULL DEFAULT '' COMMENT '实例类型',
    app_deploy_status_type VARCHAR(50) NOT NULL DEFAULT '' COMMENT '应用状态',
    note VARCHAR(150) NOT NULL DEFAULT ''  COMMENT '应用介绍',
    is_use_deploy_template BOOLEAN NOT NULL DEFAULT false COMMENT '是否使用默认部署模板',
    deleted BOOLEAN NOT NULL DEFAULT false COMMENT '是否删除',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人Id',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人Id',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '最后修改时间',
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '删除时间'
);
CREATE INDEX idx_toyar_app_id on toyar_application (id);
CREATE INDEX idx_toyar_app_app_id on toyar_application (app_id);
CREATE INDEX idx_toyar_app_app_name on toyar_application (app_name);

--应用部署配置信息表
CREATE TABLE IF NOT EXISTS toyar_application_deployment_configuration
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT ''  COMMENT '应用标识（系统唯一）',
    environment_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '环境Id',
    health_check_mode VARCHAR(50) NOT NULL DEFAULT '' COMMENT '健康检查方式',
    health_check_url VARCHAR(50) NOT NULL DEFAULT '' COMMENT '健康检查url',
    release_strategy VARCHAR(50) NOT NULL DEFAULT '' COMMENT '发布模式',
    service_port  VARCHAR(300) NOT NULL DEFAULT '' COMMENT '服务端口',
    bot_notification_type  VARCHAR(50) NOT NULL DEFAULT '' COMMENT '发布通知类型：（企业微信、钉钉、飞书等）',
    bot_notification_url  VARCHAR(50) NOT NULL DEFAULT '' COMMENT '发布通知',
    deployment_befor_web_hook_url  VARCHAR(50) NOT NULL DEFAULT '' COMMENT '部署前回调地址',
    deployment_after_web_hook_url  VARCHAR(50) NOT NULL DEFAULT '' COMMENT '部署后回调地址',
    
    
    
    is_default_deploy BOOLEAN NOT NULL DEFAULT false  COMMENT '是否默认部署配置',
    deleted BOOLEAN NOT NULL DEFAULT false COMMENT '是否删除',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人Id',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人Id',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '最后修改时间',
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '删除时间'
);
CREATE INDEX idx_toyar_application_deployment_configuration_id on toyar_application_deployment_configuration (id);
CREATE INDEX idx_toyar_application_deployment_configuration_app_id on toyar_application_deployment_configuration (app_id);
CREATE INDEX idx_toyar_application_deployment_configuration_environment_id on toyar_application_deployment_configuration (environment_id);
CREATE INDEX idx_toyar_app_app_name on toyar_application_deployment_configuration (app_name);


--应用权限关联关系表
CREATE TABLE IF NOT EXISTS toyar_application_permission_relation
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    user_id VARCHAR(50) NOT NULL DEFAULT '',
    environment_id VARCHAR(50) NOT NULL DEFAULT '',
    role_id VARCHAR(50) NOT NULL DEFAULT '',
    deleted BOOLEAN NOT NULL DEFAULT false COMMENT '是否删除',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人Id',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人Id',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '最后修改时间',
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '删除时间'
);
CREATE INDEX idx_toyar_application_permission_relation_app_id on toyar_application_permission_relation (app_id);
CREATE INDEX idx_toyar_application_permission_relation_user_id on toyar_application_permission_relation (user_id);
CREATE INDEX idx_toyar_application_permission_relation_environment_id on toyar_application_permission_relation (environment_id);
CREATE INDEX idx_toyar_application_permission_relation_role_id on toyar_application_permission_relation (role_id);


--应用环境关联关系表
CREATE TABLE IF NOT EXISTS toyar_application_environment_relation
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    environment_id VARCHAR(50) NOT NULL DEFAULT '',
    deleted BOOLEAN NOT NULL DEFAULT false COMMENT '是否删除',
    create_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '创建人Id',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '' COMMENT '最后修改人Id',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '最后修改时间',
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP COMMENT '删除时间'
);
CREATE INDEX idx_toyar_application_environment_relation_app_id on toyar_application_environment_relation (app_id);
CREATE INDEX idx_toyar_application_environment_relation_environment_id on toyar_application_environment_relation (environment_id);


